using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Participant.Commands;

public class ParticipantCreateCmdHandler : IRequestHandler<ParticipantCreateCmd, ParticipantGetDto>
{
    private readonly IUnitOfService _service;
    public ParticipantCreateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<ParticipantGetDto> Handle(ParticipantCreateCmd request, CancellationToken cancellationToken)
    {
        var ParticipantPostDTO = new ParticipantCreateDto(
             request.FirstName,
             request.LastName,
             request.Email,
             request.Phone,
             request.Gender,
             request.City
            );
        var Participant = await _service.ParticipantService.CreateAsync(ParticipantPostDTO);
        return Participant;
    }
}