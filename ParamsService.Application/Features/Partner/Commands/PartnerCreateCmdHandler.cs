using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Commands;

public class EventPartnerCreateCmdHandler : IRequestHandler<PartnerCreateCmd, PartnerGetDto>
{
    private readonly IUnitOfService _service;
    public EventPartnerCreateCmdHandler(IUnitOfService service) => _service = service;

    public async Task<PartnerGetDto> Handle(PartnerCreateCmd request, CancellationToken cancellationToken)
    {
        var partnerPostDTO = new PartnerCreateDto(
             request.Name,
             request.Description,
             request.Logo
            );
        var partner = await _service.PartnerService.CreateAsync(partnerPostDTO);
        return partner;
    }
}