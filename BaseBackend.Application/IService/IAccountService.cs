using BaseBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public interface IAccountService : IBaseService<AccountDTO, AccountFilter>
    {
    }
}
