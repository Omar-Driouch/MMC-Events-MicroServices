using Microsoft.AspNetCore.Mvc;
using ParamsService.Application.Features.Sponsor.Commands;
using ParamsService.Application.Features.Sponsor.Queries;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var sponsors = await Mediator.Send(new SponsorFindAllQuery());
            return Ok(sponsors);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var sponsor = await Mediator.Send(new SponsorFindQuery(Id));
            return sponsor is null ? NotFound() : Ok(sponsor);
        }

        [HttpPost]

        public async Task<IActionResult> Create(SponsorCreateCmd cmd)
        {
            var sponsor = await Mediator.Send(cmd);
            return sponsor is null ? NotFound() : Ok(sponsor);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(SponsorUpdateCmd cmd)
        {
            var sponsor = await Mediator.Send(cmd);
            return sponsor is null ? NotFound() : Ok(sponsor);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await Mediator.Send(new SponsorDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }
    }
}
