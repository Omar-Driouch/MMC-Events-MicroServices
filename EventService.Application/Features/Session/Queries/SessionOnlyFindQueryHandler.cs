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
    public class SessionOnlyFindQueryHandler : IRequestHandler<SessionOnlyFindQuery, IEnumerable<SessionOnlyGetDTO>>
    {
        private readonly IUnitOfService _service;
        public SessionOnlyFindQueryHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<SessionOnlyGetDTO>> Handle(SessionOnlyFindQuery request, CancellationToken cancellationToken)
        {
            var sessionsOnly = await _service.SessionService.FindAllSession();
            return sessionsOnly;
        }
    }
}
