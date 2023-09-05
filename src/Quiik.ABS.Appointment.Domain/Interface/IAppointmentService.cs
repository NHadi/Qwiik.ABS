using Quiik.ABS.Appointment.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Domain.Interface
{
    public interface IAppointmentService
    {
        string BookAppointment(BookAppointmentRequest request);
        List<BookAppointmentResponse> GetAppointmentsForDay(DateTime date);
    }
}
