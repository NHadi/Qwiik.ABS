using Microsoft.EntityFrameworkCore;
using Quiik.ABS.Appointment.Domain;
using Quiik.ABS.Appointment.Domain.Interface;
using Quiik.ABS.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Infrastructure.Repositories
{
    public class AppointmentConfigurationRepository : EfRepository<AppointmentConfiguration>, IAppointmentConfigurationRepository
    {
        private readonly ABS_AppointmentsContext _context;
        private readonly IAppointmentRepository apppointmentRepository;
        public AppointmentConfigurationRepository(ABS_AppointmentsContext context, IAppointmentRepository apppointmentRepository) : base(context)
        {
            _context = context;
            this.apppointmentRepository = apppointmentRepository;
        }

        public bool IsMaximumAppointmentsReached(DateTime date)
        {
            var valid = true;

            var data = apppointmentRepository.GetAppointmentsForDay(date);

            var config = _context.AppointmentConfiguration.FirstOrDefault();
            if (config != null) valid = data.Count >= config.MaxPerDay;

            return valid;
        }
    }
}
