using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Features.Session.Queries
{

    public class SessionOnlyFindByIdQueryHandler : IRequestHandler<SessionOnlyFindByIdQuery, SessionOnlyGetDTO>
    {
        private readonly IUnitOfService _service;
        public SessionOnlyFindByIdQueryHandler(IUnitOfService service) => _service = service;




        public async Task<SessionOnlyGetDTO> Handle(SessionOnlyFindByIdQuery request, CancellationToken cancellationToken)
        {
            var session = await _service.SessionService.FindSessionOnlyByIdAsync(request.Id);
            return session;
        }

        
    }
}
