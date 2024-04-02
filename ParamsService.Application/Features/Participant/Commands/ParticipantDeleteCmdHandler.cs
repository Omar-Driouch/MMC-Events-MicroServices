using MediatR;
using ParamsService.Application.Interfaces;


namespace MMC.Application.Features.Participant.Commands;

public class ParticipantDeleteCmdHandler : IRequestHandler<ParticipantDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public ParticipantDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(ParticipantDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.ParticipantService.DeleteAsync(request.Id);
        return success;
    }
}