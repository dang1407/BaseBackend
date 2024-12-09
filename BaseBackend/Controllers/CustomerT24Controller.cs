using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    public class CustomerT24Controller : BaseController<CustomerT24DTO, CustomerT24Filter>
    {
        private readonly ICustomerT24Service customerT24Service;
        public CustomerT24Controller(ICustomerT24Service baseService) : base(baseService, 5)
        {
            customerT24Service = baseService;
        }

        [HttpGet]
        [Route("SeedAccountInfo")]
        public IActionResult Seed()
        {
             customerT24Service.SeadData();
            return Ok();
        }
    }
}
