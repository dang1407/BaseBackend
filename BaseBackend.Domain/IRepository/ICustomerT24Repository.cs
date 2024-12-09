using BaseBackend.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Domain
{
    public interface ICustomerT24Repository : IBaseRepository<CustomerT24, CustomerT24Filter>
    {
        void SeedAccountInfo();
    }
}
