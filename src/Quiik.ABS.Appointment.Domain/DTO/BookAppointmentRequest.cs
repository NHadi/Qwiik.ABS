using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Domain.DTO
{
    public class BookAppointmentRequest
    {
        public int CustomerId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
