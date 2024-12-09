using AutoMapper;
using BaseBackend.Domain;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class CustomerT24Service : BaseService<CustomerT24, CustomerT24DTO, CustomerT24Filter>, ICustomerT24Service
    {
        private readonly ICustomerT24Repository _repository;
        public CustomerT24Service(ICustomerT24Repository baseRepository, IMapper mapper, IMemoryCache memoryCache, IPermisionService permisionService) : base(baseRepository, mapper, memoryCache, permisionService)
        {
            _repository = baseRepository;
        }

        public void SeadData()
        {
            _repository.SeedAccountInfo();
        }
    }
}
