using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.Features.City.Queries;
using MMC.Application.Features.City.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ApiBaseController
    {

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var cities = await Mediator.Send(new CityFindAllQuery());
            return Ok(cities);
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> Find(Guid Id)
        {
            var city = await Mediator.Send(new CityFindQuery(Id));
            return city is null ? NotFound() : Ok(city);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CityCreateCmd cmd)
        {
            var city = await Mediator.Send(cmd);
            return city is null ? NotFound() : Ok(city);
        }

        [HttpPut(template: $"{{Id}}")]
        public async Task<IActionResult> Update(CityUpdateCmd cmd)
        {
            var city = await Mediator.Send(cmd);
            return city is null ? NotFound() : Ok(city);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success =  await Mediator.Send(new CityDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }

    }
}
