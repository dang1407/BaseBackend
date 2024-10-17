using BaseBackend.Application;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using BaseBackend.Domain.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeeDTO, EmployeeDTO, EmployeeDTO, EmployeeFilter>
    {
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
        }
    }
}
