//using EventService.API.Services;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace EventService.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SessionParticipant : ControllerBase
//    {
//        private readonly IRabbitMQ _rabbitMQ;

//        public SessionParticipant(IRabbitMQ rabbitMQ)
//        {
//            _rabbitMQ = rabbitMQ;
//        }
//        // POST: api/Test/City
//        [HttpGet("MMC/{Service}/{message}")]
//        public async Task<IActionResult> SendCityRequest(string Service, string message)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(message))
//                {
//                    return BadRequest("Message cannot be null or empty");
//                }

//                Console.WriteLine("Send :" + message);
//                var data = _rabbitMQ.Call(Service, message);
//                return Ok(data);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
//            }
//        }
//    }
//}
