using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventParticipant.Queries;

public class EventParticipantFindAllQueryHandler : IRequestHandler<EventParticipantFindAllQuery, IEnumerable<EventParticipantGetDto>>
{
    private readonly IUnitOfService _service;
    public EventParticipantFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<EventParticipantGetDto>> Handle(EventParticipantFindAllQuery request, CancellationToken cancellationToken)
    {
        var partners = await _service.EventParticipantService.FindAllAsync();
        return partners;
    }
}