using Microsoft.AspNetCore.Mvc;
using ParamsService.Application.Features.Theme.Commands;
using ParamsService.Application.Features.Theme.Queries;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var themes = await Mediator.Send(new ThemeFindAllQuery());
            return Ok(themes);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var theme = await Mediator.Send(new ThemeFindQuery(Id));
            return theme is null ? NotFound() : Ok(theme);
        }

        [HttpPost]

        public async Task<IActionResult> Create(ThemeCreateCmd cmd)
        {
            var theme = await Mediator.Send(cmd);
            return theme is null ? NotFound() : Ok(theme);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(ThemeUpdateCmd cmd)
        {
            var theme = await Mediator.Send(cmd);
            return theme is null ? NotFound() : Ok(theme);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await Mediator.Send(new ThemeDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }

    }
}
