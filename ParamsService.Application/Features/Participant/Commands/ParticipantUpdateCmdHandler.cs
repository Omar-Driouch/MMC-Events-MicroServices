using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.Participant.Commands;

public class ParticipantUpdateCmdHandler : IRequestHandler<ParticipantUpdateCmd, ParticipantGetDto>
{
    private readonly IUnitOfService _service;
    public ParticipantUpdateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<ParticipantGetDto> Handle(ParticipantUpdateCmd request, CancellationToken cancellationToken)
    {
        var participantPutDTO = new ParticipantUpdateDto(
            request.Id,
            request.FirstName,
             request.LastName,
             request.Email,
             request.Phone,
             request.Gender,
             request.City);
        var participant = await _service.ParticipantService.UpdateAsync(participantPutDTO);
        return participant;
    }
}