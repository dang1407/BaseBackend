using BaseBackend.Application;
using BaseBackend.Application.IService;
using BaseBackend.Domain.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers
{
    //[Authorize]
    public class TitleController : BaseController<TitleDTO, TitleFilter, Guid>
    {
        public TitleController(ITitleService baseService) : base(baseService, 2)
        {
        }
    }
}
