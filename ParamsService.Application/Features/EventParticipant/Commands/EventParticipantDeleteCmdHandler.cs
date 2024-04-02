using MediatR;
using ParamsService.Application.Interfaces;


namespace MMC.Application.Features.EventParticipant.Commands;

public class EventParticipantDeleteCmdHandler : IRequestHandler<EventParticipantDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public EventParticipantDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(EventParticipantDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.EventParticipantService.DeleteAsync(id: request.Id);
        return success;
    }
}