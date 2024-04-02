using MediatR;
using ParamsService.Application.Interfaces;


namespace MMC.Application.Features.EventPartner.Commands;

public class EventPartnerDeleteCmdHandler : IRequestHandler<EventPartnerDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public EventPartnerDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(EventPartnerDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.EventPartnerService.DeleteAsync(request.Id);
        return success;
    }
}