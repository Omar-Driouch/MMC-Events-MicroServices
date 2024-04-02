using Microsoft.AspNetCore.Mvc;
using ParamsService.Application.Features.Mode.Commands;
using ParamsService.Application.Features.Mode.Queries;
using ParamsService.Application.Features.Theme.Commands;
using ParamsService.Application.Features.Theme.Queries;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var modes = await Mediator.Send(new ModeFindAllQuery());
            return Ok(modes);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var mode = await Mediator.Send(new ModeFindQuery(Id));
            return mode is null ? NotFound() : Ok(mode);
        }

        [HttpPost]

        public async Task<IActionResult> Create(ModeCreateCmd cmd)
        {
            var mode = await Mediator.Send(cmd);
            return mode is null ? NotFound() : Ok(mode);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(ModeUpdateCmd cmd)
        {
            var mode = await Mediator.Send(cmd);
            return mode is null ? NotFound() : Ok(mode);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await Mediator.Send(new ModeDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }
    }
}
