using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TDTO, TFilter> : ControllerBase where TFilter : BaseFilter
    {
        protected readonly IBaseReadOnlyService<TDTO, TFilter> BaseReadOnlyService;

        public BaseReadOnlyController(IBaseReadOnlyService<TDTO, TFilter> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        // Các hàm get chung sẽ được viết ở đây tùy theo nhu cầu dự án
        [HttpPost]
        [Route("paging")]    
        public async Task<IActionResult> GetPaging([FromBody] RequestDTO request)
        {
            var result = await BaseReadOnlyService.GetPaging(request.PagingInfo, request.Filter);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await BaseReadOnlyService.GetByIdAsync(id);    
            return Ok(result);  
        }

        public class RequestDTO
        {
            public PagingInfo PagingInfo { get; set; } = new PagingInfo();
            public TFilter? Filter { get; set; }
        }
    }
}
