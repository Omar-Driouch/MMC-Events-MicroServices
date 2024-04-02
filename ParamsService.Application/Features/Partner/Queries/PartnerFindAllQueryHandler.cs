using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Queries;

public class PartnerFindAllQueryHandler : IRequestHandler<PartnerFindAllQuery, IEnumerable<PartnerGetDto>>
{
    private readonly IUnitOfService _service;
    public PartnerFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<PartnerGetDto>> Handle(PartnerFindAllQuery request, CancellationToken cancellationToken)
    {
        var partners = await _service.PartnerService.FindAllAsync();
        return partners;
    }
}