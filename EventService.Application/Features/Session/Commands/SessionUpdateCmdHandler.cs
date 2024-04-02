using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Features.Session.Commands
{

    public class SessionUpdateCmdHandler : IRequestHandler<SessionUpdateCmd, SessionGetDTO>
    {
        private readonly IUnitOfService _service;
        public SessionUpdateCmdHandler(IUnitOfService service) => _service = service;




        public async Task<SessionGetDTO> Handle(SessionUpdateCmd request, CancellationToken cancellationToken)
        {
            var sessionPutDTO = new SessionPutDTO
            (
                request.Id,
                request.Name,
                request.NumPlace,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.EventId,
                request.ModeId
            );
            var session = await _service.SessionService.UpdateAsync(sessionPutDTO);
            return session;
        }
    }
}
