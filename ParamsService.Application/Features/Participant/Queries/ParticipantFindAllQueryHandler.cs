using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Participant.Queries;

public class ParticipantFindAllQueryHandler : IRequestHandler<ParticipantFindAllQuery, IEnumerable<ParticipantGetDto>>
{
    private readonly IUnitOfService _service;
    public ParticipantFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<ParticipantGetDto>> Handle(ParticipantFindAllQuery request, CancellationToken cancellationToken)
    {
        var participants = await _service.ParticipantService.FindAllAsync();
        return participants;
    }
}