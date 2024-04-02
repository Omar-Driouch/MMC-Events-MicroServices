using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventPartner.Queries;

public class EventPartnerFindAllQueryHandler : IRequestHandler<EventPartnerFindAllQuery, IEnumerable<EventPartnerGetDto>>
{
    private readonly IUnitOfService _service;
    public EventPartnerFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<EventPartnerGetDto>> Handle(EventPartnerFindAllQuery request, CancellationToken cancellationToken)
    {
        var partners = await _service.EventPartnerService.FindAllAsync();
        return partners;
    }
}