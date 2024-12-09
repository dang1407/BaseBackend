using AutoMapper;
using BaseBackend.Application.IService;
using BaseBackend.Domain;
using BaseBackend.Domain.Filter;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Application
{
    public class TitleService : BaseService<Title, TitleDTO,TitleFilter>, ITitleService
    {
        public TitleService(ITitleRepository baseRepository, IMapper mapper, IMemoryCache memoryCache, IPermisionService permisionService) : base(baseRepository, mapper, memoryCache, permisionService)
        {
        }
    }
}
