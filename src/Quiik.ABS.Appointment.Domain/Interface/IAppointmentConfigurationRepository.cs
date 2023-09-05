using Quiik.ABS.Common.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Domain.Interface
{
    
    public interface IAppointmentConfigurationRepository : IEfRepository<AppointmentConfiguration>
    {
        bool IsMaximumAppointmentsReached(DateTime date);
    }
}
