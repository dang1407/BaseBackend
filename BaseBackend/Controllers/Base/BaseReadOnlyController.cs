using BaseBackend.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseReadOnlyController<TDTO> : ControllerBase
    {
        protected readonly IBaseReadOnlyService<TDTO> BaseReadOnlyService;

        public BaseReadOnlyController(IBaseReadOnlyService<TDTO> baseReadOnlyService)
        {
            BaseReadOnlyService = baseReadOnlyService;
        }

        // Các hàm get chung sẽ được viết ở đây tùy theo nhu cầu dự án
        [HttpGet]
        [Route("")]    
        public async Task<IActionResult> GetFilterAsync(int page, int pageSize, string property)
        {
            var result = await BaseReadOnlyService.GetFilterAsync(page, pageSize, property);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await BaseReadOnlyService.GetByIdAsync(id);    
            return Ok(result);  
        }
    }
}
