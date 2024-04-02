using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Queries;

public class PartnerFindQueryHandler : IRequestHandler<PartnerFindQuery, PartnerGetDto>
{
    private readonly IUnitOfService _service;
    public PartnerFindQueryHandler(IUnitOfService service) => _service = service;




    public async Task<PartnerGetDto> Handle(PartnerFindQuery request, CancellationToken cancellationToken)
    {
        var Partner = await _service.PartnerService.FindAsync(request.Id);
        return Partner;
    }
}