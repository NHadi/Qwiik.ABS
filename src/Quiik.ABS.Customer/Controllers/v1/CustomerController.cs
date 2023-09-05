using Microsoft.AspNetCore.Mvc;
using Quiik.ABS.Common.DTO;
using Quiik.ABS.Customer.Domain.DTO;
using Quiik.ABS.Customer.Domain.Interface;

namespace Quiik.ABS.Customer.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger, IWebHostEnvironment env)
        {
            this.customerService = customerService;
            _logger = logger;
            _env = env;
        }


        [HttpPost]
        public IActionResult Save([FromForm] CustomerRequest request)
        {
            try
            {
                var response = customerService.Save(request);
                return Ok(new ApiOkResponse(response));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("{name}/Name")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var response = customerService.Get(new CustomerRequest { Name = name});
                return Ok(new ApiOkResponse(response, response.Count));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("{email}/Email")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                var response = customerService.Get(new CustomerRequest { Email = email });
                return Ok(new ApiOkResponse(response, response.Count));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = customerService.Get(new CustomerRequest());
                return Ok(new ApiOkResponse(response, response.Count));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}