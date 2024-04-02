using Microsoft.AspNetCore.Mvc;

namespace SpeakerService.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRabbitMQ _rabbitMQ;
        public TestController(IRabbitMQ rabbitMQ)
        {
            _rabbitMQ= rabbitMQ;
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(string message)
        {
            if (!ModelState.IsValid)
            {
                return Ok("message null");
            }
            Console.WriteLine("Send :"+message);
            var data =_rabbitMQ.Call(message);
            return Ok(data);
        }
    }
}
