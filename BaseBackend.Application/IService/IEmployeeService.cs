using BaseBackend.Domain;
using BaseBackend.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application.IService
{
    public interface IEmployeeService : IBaseService<EmployeeDTO, EmployeeFilter>
    {
    }
}
