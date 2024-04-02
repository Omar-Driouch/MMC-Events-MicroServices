using MediatR;
using ParamsService.Application.Interfaces;


namespace MMC.Application.Features.Participant.Commands;

public class PartnerDeleteCmdHandler : IRequestHandler<PartnerDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public PartnerDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(PartnerDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.PartnerService.DeleteAsync(request.Id);
        return success;
    }
}