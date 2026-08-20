using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace BaseBackend.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _redisDb;

        // Inject IConnectionMultiplexer vào Controller
        public CacheController(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }

        // 1. API Lưu dữ liệu vào Redis (POST api/cache)
        [HttpPost]
        public async Task<IActionResult> SetCache([FromQuery] string key, [FromQuery] string value, [FromQuery] int minutesToExpire = 5)
        {
            var expiry = TimeSpan.FromMinutes(minutesToExpire);
            bool isSuccess = await _redisDb.StringSetAsync(key, value, expiry);

            if (isSuccess)
                return Ok(new { Message = $"Đã lưu Key '{key}' thành công!" });

            return BadRequest("Không thể lưu dữ liệu.");
        }

        // 2. API Lấy dữ liệu từ Redis (GET api/cache/{key})
        [HttpGet("{key}")]
        public async Task<IActionResult> GetCache(string key)
        {
            var value = await _redisDb.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return NotFound(new { Message = $"Không tìm thấy Key '{key}' hoặc đã hết hạn." });

            return Ok(new { Key = key, Value = value.ToString() });
        }
    }
}
