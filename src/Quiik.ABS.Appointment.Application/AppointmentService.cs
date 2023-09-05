using AutoMapper;
using Quiik.ABS.Appointment.Domain;
using Quiik.ABS.Appointment.Domain.DTO;
using Quiik.ABS.Appointment.Domain.Interface;
using System.Collections.Generic;

namespace Quiik.ABS.Appointment.Application
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ITokenRepository tokenRepository;
        private readonly IAppointmentRepository apppointmentRepository;
        private readonly IAppointmentConfigurationRepository appointmentConfigurationRepository;
        private readonly IMapper mapper;
        public AppointmentService(IAppointmentRepository apppointmentRepository, IAppointmentConfigurationRepository appointmentConfigurationRepository,
            IMapper mapper,
            ITokenRepository tokenRepository)
        {
            this.apppointmentRepository = apppointmentRepository;
            this.appointmentConfigurationRepository = appointmentConfigurationRepository;
            this.tokenRepository = tokenRepository;
            this.mapper = mapper;
        }     

        public string BookAppointment(BookAppointmentRequest request)
        {
            try
            {
                var data = mapper.Map<Appointments>(request);
                
                if (data.IsWeekend())
                    throw new Exception("Selected date is a weekend");

                if (IsPublicHoliday(data.DateTime))
                    throw new Exception("Selected date is a public holiday.");

                if (appointmentConfigurationRepository.IsMaximumAppointmentsReached(data.DateTime))
                    data.DateTime = GetNextAvailableDay(data);

                var IssueToken = new Tokens();
                IssueToken.Status = "PENDING";
                IssueToken.TokenNumber = IssueToken.GenerateToken(10);
                
                tokenRepository.Insert(IssueToken);
                tokenRepository.Save();

                data.TokenId = IssueToken.TokenId;
                data.CreatedBy = "Admin";
                data.CreateDate = DateTime.Now;
                data.IsActive = true;

                apppointmentRepository.Insert(data);
                apppointmentRepository.Save();

                return IssueToken.TokenNumber;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<BookAppointmentResponse> GetAppointmentsForDay(DateTime date)
        {
            try
            {
                var data = mapper.Map<List<BookAppointmentResponse>>(apppointmentRepository.GetAppointmentsForDay(date));
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        // Example, the real will be use databases, because other country will be have different public holiday
        private static bool IsPublicHoliday(DateTime date)
        {
            // Sample list of public holidays (you can load this from a data source or configuration file)
            List<DateTime> publicHolidays = new List<DateTime>
            {
                new DateTime(DateTime.Now.Year, 1, 1),    // New Year's Day
                new DateTime(DateTime.Now.Year, 7, 4),    // Independence Day
                new DateTime(DateTime.Now.Year, 12, 25),  // Christmas Day               
            };

            foreach (DateTime holiday in publicHolidays)
            {
                if (date.Date == holiday.Date)
                {
                    return true;
                }
            }

            return false;
        }

        private DateTime GetNextAvailableDay(Appointments appointments)
        {
            bool validDate = false;
            do
            {
                validDate = true;
                appointments.DateTime = appointments.DateTime.AddDays(1);

                if (appointments.IsWeekend()) { validDate = false; }
                if (IsPublicHoliday(appointments.DateTime)) { validDate = false; }
                if (!validDate) appointments.DateTime.AddDays(1);

            } while (!validDate);

            return appointments.DateTime;
        }
    }
}
