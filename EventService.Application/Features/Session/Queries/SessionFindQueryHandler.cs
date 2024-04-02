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
    public class SessionFindQueryHandler : IRequestHandler<SessionFindQuery, SessionGetDTO>
    {
        private readonly IUnitOfService _service;
        public SessionFindQueryHandler(IUnitOfService service) => _service = service;




        public async Task<SessionGetDTO> Handle(SessionFindQuery request, CancellationToken cancellationToken)
        {
            var session = await _service.SessionService.FindAsync(request.Id);
            return session;
        }
    }
}
