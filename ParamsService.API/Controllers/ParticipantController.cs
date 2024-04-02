using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.Features.Participant.Commands;
using MMC.Application.Features.Participant.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ApiBaseController
    {

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var participants = await Mediator.Send(new ParticipantFindAllQuery());
            return Ok(participants);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var participant = await Mediator.Send(new ParticipantFindQuery(Id));
            return participant is null ? NotFound() : Ok(participant);
        }

        [HttpPost]

        public async Task<IActionResult> Create(ParticipantCreateCmd cmd)
        {
            var participant = await Mediator.Send(cmd);
            return participant is null ? NotFound() : Ok(participant);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(ParticipantUpdateCmd cmd)
        {
            var participant = await Mediator.Send(cmd);
            return participant is null ? NotFound() : Ok(participant);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await Mediator.Send(new ParticipantDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }

    }
}
