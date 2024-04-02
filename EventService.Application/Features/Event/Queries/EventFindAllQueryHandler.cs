using MediatR;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Queries;

public class EventFindAllQueryHandler : IRequestHandler<EventFindAllQuery, IEnumerable<EventGetDTO>>
{
    private readonly IUnitOfService _service;
    public EventFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<EventGetDTO>> Handle(EventFindAllQuery request, CancellationToken cancellationToken)
    {
        var events = await _service.EventService.FindAllAsync();
        return events;
    }
}