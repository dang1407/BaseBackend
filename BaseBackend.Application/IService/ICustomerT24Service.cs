using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface ICustomerT24Service : IBaseService<CustomerT24DTO, CustomerT24Filter>
    {
        public void SeadData();
    }
}
