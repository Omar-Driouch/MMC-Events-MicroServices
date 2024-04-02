using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.Features.Participant.Commands;
using MMC.Application.Features.Partner.Commands;
using MMC.Application.Features.Partner.Queries;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var partners = await Mediator.Send(new PartnerFindAllQuery());
            return Ok(partners);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var partner = await Mediator.Send(new PartnerFindQuery(Id));
            return partner is null ? NotFound() : Ok(partner);
        }

        [HttpPost]

        public async Task<IActionResult> Create(PartnerCreateCmd cmd)
        {
            var partner = await Mediator.Send(cmd);
            return partner is null ? NotFound() : Ok(partner);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(PartnerUpdateCmd cmd)
        {
            var partner = await Mediator.Send(cmd);
            return partner is null ? NotFound() : Ok(partner);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await Mediator.Send(new PartnerDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }
    }
}
