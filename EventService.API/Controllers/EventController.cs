using EventService.API.Services;
using EventService.Application.Features.Event.Commands;
using EventService.Application.Features.Event.Queries;
using EventService.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventService.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ApiControllerBase
    {
       private readonly IRabbitMQ _rabbitmqServer;
       private readonly IEventSpeakers _rabbitmqSpeakerServer;
        public EventController(IRabbitMQ rabbitmqServer, IEventSpeakers rabbitmqSpeakerServer)
        {
            _rabbitmqServer = rabbitmqServer;
            _rabbitmqSpeakerServer = rabbitmqSpeakerServer;
        }
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var events = await Mediator.Send(new EventFindAllQuery());
            return Ok(events);
        }
        [HttpGet("GetOnlyEvents")]
        public async Task<IActionResult> FindAllEventOnly()
        {
            var events = await Mediator.Send(new EventOnlyFindAllQuery());
            return Ok(events);
        }
        [HttpGet("GetEventOnlyById/{Id}")]

        public async Task<IActionResult> FindEventOnlyByid(Guid Id)
        {
            var events = await Mediator.Send(new EventOnlyFindByIdQuery(Id));
            return Ok(events);
        }


        [HttpGet("GetEventsByProgramId/{Id}")]
        public async Task<IActionResult> FindAllByProgramId(Guid Id)
        {
            var events = await Mediator.Send(new EventFindAllByProgramIdQuery(Id));
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(Guid id)
        {
            var @event = await Mediator.Send(new EventFindQuery(id));
            
            return @event is null ? NotFound() : Ok(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventCreateCmd cmd)
        {
            var @event = await Mediator.Send(cmd);
            return CreatedAtAction(nameof(Find), new { id = @event.Id }, @event);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EventUpdateCmd cmd)
        {
            try
            {
                var @event = await Mediator.Send(cmd);
                return Ok(@event);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await Mediator.Send(new EventDeleteCmd(id));
            var tt  = await _rabbitmqServer.DeleteMethod("Participant", "Delete",id);
            var ts = await _rabbitmqSpeakerServer.DeleteMethod("Speaker", "Delete", id);
            return success ? Ok(success) : NotFound();
        }
    }
}
