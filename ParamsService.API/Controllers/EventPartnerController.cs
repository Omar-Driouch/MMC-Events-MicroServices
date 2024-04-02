using ParamsService.API.Services;
using Microsoft.AspNetCore.Mvc;
using ParamsService.Domain.DTOs;
using MediatR;
using MMC.Application.Features.EventPartner.Commands;
using MMC.Application.Features.Partner.Commands;
using MMC.Application.Features.EventPartner.Queries;
using MMC.Application.Features.EventParticipant.Commands;


namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPartnerController : ControllerBase
    {
        private readonly IRabbitMQ _rabbitMQ;
        private readonly IMediator _mediator;

        public EventPartnerController(IRabbitMQ rabbitMQ, IMediator mediator)
        {
            _rabbitMQ = rabbitMQ;
            _mediator = mediator;
        }
        // POST: api/EventPartner
        [HttpPost]
        public async Task<IActionResult> Create(EventPartnerCreateCmd cmd)
        {
            var partner = await _mediator.Send(cmd);
            return partner is null ? NotFound() : Ok(partner);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var partners = await _mediator.Send(new EventPartnerFindAllQuery());
            return Ok(partners);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> FindPartnersByEvent(Guid Id)
        {
            var partner = await _mediator.Send(new EventPartnerFindQuery(Id));
            return partner is null ? NotFound() : Ok(partner);
        }




        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await _mediator.Send(new EventParticipantDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }


    }
}
