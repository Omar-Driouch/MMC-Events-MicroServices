using MediatR;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Commands;

public class EventUpdateCmdHandler : IRequestHandler<EventUpdateCmd, EventGetDTO>
{
    private readonly IUnitOfService _service;
    public EventUpdateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<EventGetDTO> Handle(EventUpdateCmd request, CancellationToken cancellationToken)
    {
        var eventPutDTO = new EventPutDTO
        (
            request.Id,
            request.Title,
            request.Address,
            request.Description,
            request.ImagePath,
            request.StartDate,
            request.EndDate,
            request.CityId,
            request.ThemeId,
            request.ProgramId
        );

        var @event = await _service.EventService.UpdateAsync(eventPutDTO);
        return @event;
    }
}