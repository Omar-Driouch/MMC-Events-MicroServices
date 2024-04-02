using EventService.Application.Features.Event.Commands;
using EventService.Application.Features.Event.Queries;
using EventService.Application.Features.Program.Commands;
using EventService.Application.Features.Program.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EventService.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var programs = await Mediator.Send(new ProgramFindAllQuery());
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(Guid id)
        {
            var @program = await Mediator.Send(new ProgramFindQuery(id));
            return @program is null ? NotFound() : Ok(@program);
        }
        [HttpGet("GetAllProgramsOnly")]
        public async Task<IActionResult> FindProgramOnly()
        {
            var @program = await Mediator.Send(new ProgramOnlyFindAllQuery());
            return @program is null ? NotFound() : Ok(@program);
        }

        [HttpGet("GetProgramOnlyById/{id}")]
        public async Task<IActionResult> FindProgramOnlyById(Guid id)
        {
            var @program = await Mediator.Send(new ProgramOnlyFindQuery(id));
            return @program is null ? NotFound() : Ok(@program);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProgramCreateCmd cmd)
        {
            var @program = await Mediator.Send(cmd);
            return CreatedAtAction(nameof(Find), new { id = @program.Id }, @program);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProgramUpdateCmd cmd)
        {
            try
            {
                var @program = await Mediator.Send(cmd);
                return Ok(@program);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await Mediator.Send(new ProgramDeleteCmd(id));
            return success ? Ok(success) : NotFound();
        }
    }
}
