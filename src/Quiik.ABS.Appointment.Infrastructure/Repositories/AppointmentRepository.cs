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
    public class AppointmentRepository : EfRepository<Appointments>, IAppointmentRepository
    {
        private readonly ABS_AppointmentsContext _context;
        public AppointmentRepository(ABS_AppointmentsContext context) : base(context)
        {
            _context = context;
        }

        
        public Appointments? GetAppointmentsByToken(string token)
        {
           return _context.Appointments
                .Include(x => x.Token)
                .FirstOrDefault(x => x.Token.TokenNumber == token);

           
        }

        public List<Appointments> GetAppointmentsForDay(DateTime date)
        {
            //EF.Functions.TruncateTime not found
            return _context.Appointments
                .Include(x => x.Token)
                .Where(x => x.DateTime.Year == date.Year && 
                                                x.DateTime.Month == date.Month && 
                                                x.DateTime.Day == date.Day).ToList();
        }
    }
}
