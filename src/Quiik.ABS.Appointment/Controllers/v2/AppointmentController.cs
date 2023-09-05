using Microsoft.AspNetCore.Mvc;
using Quiik.ABS.Appointment.Domain.DTO;
using Quiik.ABS.Appointment.Domain.Interface;
using Quiik.ABS.Common.DTO;

namespace Quiik.ABS.Appointment.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService, ILogger<AppointmentController> logger, IWebHostEnvironment env)
        {
            this.appointmentService = appointmentService;
            _logger = logger;
            _env = env;
        }


        [Route("BookAppointment")]
        [HttpPost]
        public IActionResult BookAppointment([FromForm] BookAppointmentRequest request)
        {
            try
            {
                var response = appointmentService.BookAppointment(request);
                return Ok(new ApiResponse(200, $"TOKEN {response}"));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [Route("{date}/Bydate")]
        [HttpGet]
        public IActionResult ByDate(DateTime date)
        {
            try
            {
                var response = appointmentService.GetAppointmentsForDay(date);
                return Ok(new ApiOkResponse(response, response.Count));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}