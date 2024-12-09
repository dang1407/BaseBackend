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
    public class AdmFeatureFunctionService : BaseService<AdmFeatureFunction, AdmFeatureFunctionDTO, AdmFeatureFunctionFilter>, IAdmFeatureFunctionService
    {
        public AdmFeatureFunctionService(IAdmFeatureFunctionRepository repository, IMapper mapper, IMemoryCache memoryCache, IPermisionService permisionService) : base(repository, mapper, memoryCache, permisionService) { }
    }
}
