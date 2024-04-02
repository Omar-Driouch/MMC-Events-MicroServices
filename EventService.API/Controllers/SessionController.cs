using EventService.API;
using EventService.API.Services;
using EventService.Application.Features.Event.Queries;
using EventService.Application.Features.Session.Commands;
using EventService.Application.Features.Session.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventService.APi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ApiControllerBase
    {
        private readonly IRabbitMQ _rabbitMQ;
        public SessionController(IRabbitMQ rabbitMQ)
        {
            _rabbitMQ = rabbitMQ;
        }
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var sessions = await Mediator.Send(new SessionFindAllQuery());
            return Ok(sessions);
        }
        [HttpGet("SessionOnly")]
        public async Task<IActionResult> FindAllSession()
        {
            var sessions = await Mediator.Send(new SessionOnlyFindQuery());
            return Ok(sessions);
        } 

        [HttpGet("GetSessionByEventId/{Id}")]
        public async Task<IActionResult> FindAllByEventId(Guid Id)
        {
            var sessions = await Mediator.Send(new SessionFindAllQueryByEventId(Id));
            return Ok(sessions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(Guid id)
        {
            var session = await Mediator.Send(new SessionFindQuery(id));
            return session is null ? NotFound() : Ok(session);
        }

        [HttpGet("SessionOnlyById/{id}")]
        public async Task<IActionResult> FindSessionOnlyById(Guid id)
        {
            var session = await Mediator.Send(new SessionOnlyFindByIdQuery(id));
            return session is null ? NotFound() : Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SessionCreateCmd cmd)
        {
            var session = await Mediator.Send(cmd);
            return CreatedAtAction(nameof(Find), new { id = session.Id }, session);
        }

        //[HttpPost("sessionSpeaker")]
        //public string CreateSessionSpeaker(string service, string message)
        //{
        //    var sessionSpeaker = _rabbitMQ.Call(service, message);
        //    return sessionSpeaker ;
        //}

        [HttpPut]
        public async Task<IActionResult> Update(SessionUpdateCmd cmd)
        {
            var session = await Mediator.Send(cmd);
            return Ok(session);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await Mediator.Send(new SessionDeleteCmd(id));
            return success ? Ok(success) : NotFound();
        }
    }
}
