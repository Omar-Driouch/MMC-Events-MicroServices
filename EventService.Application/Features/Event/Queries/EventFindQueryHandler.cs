using MediatR;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Queries;

public class EventFindQueryHandler : IRequestHandler<EventFindQuery, EventGetDTO>
{
    private readonly IUnitOfService _service;
    public EventFindQueryHandler(IUnitOfService service) => _service = service;




    public async Task<EventGetDTO> Handle(EventFindQuery request, CancellationToken cancellationToken)
    {
        var @event = await _service.EventService.FindAsync(request.Id);
        return @event;
    }
}