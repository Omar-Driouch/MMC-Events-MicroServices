using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Participant.Queries;

public class ParticipantFindQueryHandler : IRequestHandler<ParticipantFindQuery, ParticipantGetDto>
{
    private readonly IUnitOfService _service;
    public ParticipantFindQueryHandler(IUnitOfService service) => _service = service;




    public async Task<ParticipantGetDto> Handle(ParticipantFindQuery request, CancellationToken cancellationToken)
    {
        var participant = await _service.ParticipantService.FindAsync(request.Id);
        return participant;
    }
}