
using EventService.API;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventService.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        
    }
}
