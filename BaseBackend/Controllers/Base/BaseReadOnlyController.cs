using BaseBackend.Application;
using BaseBackend.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BaseBackend.Controllers.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TDTO, TFilter, TIdKey> : ControllerBase where TFilter : BaseFilter
    {
        protected readonly IBaseReadOnlyService<TDTO, TFilter, TIdKey> BaseReadOnlyService;

        protected RequestDTO dtoResponse = new RequestDTO();
        public BaseReadOnlyController(IBaseReadOnlyService<TDTO, TFilter, TIdKey> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        // Các hàm get chung sẽ được viết ở đây tùy theo nhu cầu dự án
        [HttpPost]
        [Route("paging")]
        public async Task<IActionResult> GetPaging([FromBody] RequestDTO request)
        {
            dtoResponse.dtos = await BaseReadOnlyService.GetPaging(request.PagingInfo, request.Filter);
            return Ok(dtoResponse);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(TIdKey id)
        {
            dtoResponse.dto = await BaseReadOnlyService.GetByIdAsync(id);
            return Ok(dtoResponse);
        }

        public class RequestDTO : BaseResponseDTO
        {
            public PagingInfo PagingInfo { get; set; } = new PagingInfo();
            public TFilter? Filter { get; set; }
            public TDTO? dto { get; set; }
            public List<TDTO>? dtos { get; set; }
        }

        
    }
}
