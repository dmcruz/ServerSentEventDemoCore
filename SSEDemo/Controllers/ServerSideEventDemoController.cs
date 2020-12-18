using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SSEDemo.Controllers
{
    [Route("/api/sse")]
    public class ServerSideEventDemoController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ServerSideEventDemoController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task Get()
        {
            var response = _httpContextAccessor.HttpContext.Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            var msg = JsonSerializer.Serialize(new SSEResponse());

            while (true)
            {
                await response.WriteAsync($"data: {msg}\r\r");

                response.Body.Flush();
                await Task.Delay(3 * 1000);
            }
        }
    }
}
