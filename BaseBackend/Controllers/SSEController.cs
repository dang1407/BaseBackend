using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BaseBackend.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class SSEController : ControllerBase
    {
        [HttpGet("stream")]
        public async Task StreamEvents()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");
            Response.Headers.Add("Cache-Control", "no-cache");
            Response.Headers.Add("Connection", "keep-alive");

            var random = new Random();

            while (!HttpContext.RequestAborted.IsCancellationRequested)
            {
                var notification = new Notification
                {
                    Title = "Thông báo hệ thống",
                    Message = "Có dữ liệu mới được cập nhật",
                    Read = false,
                    Type = random.Next(0, 4) switch
                    {
                        0 => "info",
                        1 => "success",
                        2 => "warning",
                        _ => "error"
                    }
                };

                var json = JsonSerializer.Serialize(notification);

                // SSE format
                await Response.WriteAsync($"event: notification\n");
                await Response.WriteAsync($"data: {json}\n\n");
                await Response.Body.FlushAsync();

                await Task.Delay(3000); // 3s gửi 1 notification
            }
        }
    }

    public class Notification
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");
        public bool Read { get; set; }
        public string? Type { get; set; } // info | success | warning | error
    }

}
