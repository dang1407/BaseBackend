using BaseBackend.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeFilter, Guid>
    {
    }
}
