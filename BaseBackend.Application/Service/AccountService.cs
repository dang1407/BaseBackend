using AutoMapper;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class AccountService : BaseService<Account, AccountDTO, AccountFilter>, IAccountService
    {
        public AccountService(IAccountRepository baseRepository, IMapper mapper, IMemoryCache memoryCache, IPermisionService permisionService) : base(baseRepository, mapper, memoryCache, permisionService)
        {
        }
    }
}
