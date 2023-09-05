using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Domain.DTO
{
    public class BookAppointmentResponse
    {
        public int AppointmentId { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateTime { get; set; }

        public string IssueToken { get; set; }
        public string Status { get; set; }

    }
}
