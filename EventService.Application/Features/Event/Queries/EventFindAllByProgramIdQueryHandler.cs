using EventService.Application.Interfaces;
using EventService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Features.Event.Queries
{
    public class EventFindAllByProgramIdQueryHandler : IRequestHandler<EventFindAllByProgramIdQuery, IEnumerable<EventGetDTO>>
    {
        private readonly IUnitOfService _service;
        public EventFindAllByProgramIdQueryHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<EventGetDTO>> Handle(EventFindAllByProgramIdQuery request, CancellationToken cancellationToken)
        {

            var events = await _service.EventService.FindAllByProgramIdAsync(request.Id);
            return events;
        }

        
    }
}
