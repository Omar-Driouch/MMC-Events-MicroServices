using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.Partner.Commands;

public class PartnerUpdateCmdHandler : IRequestHandler<PartnerUpdateCmd, PartnerGetDto>
{
    private readonly IUnitOfService _service;
    public PartnerUpdateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<PartnerGetDto> Handle(PartnerUpdateCmd request, CancellationToken cancellationToken)
    {
        var partnerPutDTO = new PartnerUpdateDto(
            request.Id,
                  request.Name,
             request.Description,
             request.Logo
            );
        var partner = await _service.PartnerService.UpdateAsync(partnerPutDTO);
        return partner;
    }
}