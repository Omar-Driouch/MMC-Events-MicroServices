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
    public class SessionFindAllQueryByEventIdHandler : IRequestHandler<SessionFindAllQueryByEventId, IEnumerable<SessionGetDTO>>
    {
        private readonly IUnitOfService _service;
        public SessionFindAllQueryByEventIdHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<SessionGetDTO>> Handle(SessionFindAllQueryByEventId request, CancellationToken cancellationToken)
        {

            var sessions = await _service.SessionService.FindAllByEventIdAsync(request.Id);
            return sessions;
        }


    }
}
