using ConsumerService.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRabbitMQ _rabbitMQ;

        public TestController(IRabbitMQ rabbitMQ)
        {
            _rabbitMQ = rabbitMQ;
        }

        // POST: api/Test/City
        [HttpGet("MMC/{Service}/{message}")]
        public async Task<IActionResult> SendCityRequest( string Service, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    return BadRequest("Message cannot be null or empty");
                }

                Console.WriteLine("Send :" + message);
                var data =  _rabbitMQ.Call(Service, message);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        
    }
}
