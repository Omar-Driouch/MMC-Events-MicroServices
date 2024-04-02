using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventParticipant.Queries;

public class EventParticipantFindQueryHandler : IRequestHandler<EventParticipantFindQuery, IEnumerable<ParticipantGetDto>>
{
    private readonly IUnitOfService _service;

    public EventParticipantFindQueryHandler(IUnitOfService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<ParticipantGetDto>> Handle(EventParticipantFindQuery request, CancellationToken cancellationToken)
    {
        var partners = await _service.EventParticipantService.GetAllEventParticipantByEvent(request.Id);
        return partners;
    }
}
