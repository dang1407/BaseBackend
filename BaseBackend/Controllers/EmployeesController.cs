using BaseBackend.Application;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using BaseBackend.Domain.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    public class EmployeesController : BaseController<EmployeeDTO, EmployeeFilter>
    {
        public EmployeesController(IEmployeeService employeeService) : base(employeeService, 1)
        {
        }
    }
}
