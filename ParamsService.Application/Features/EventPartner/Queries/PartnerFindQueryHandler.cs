using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventPartner.Queries;

public class EventPartnerFindQueryHandler : IRequestHandler<EventPartnerFindQuery, IEnumerable<PartnerGetDto>>
{
    private readonly IUnitOfService _service;

    public EventPartnerFindQueryHandler(IUnitOfService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<PartnerGetDto>> Handle(EventPartnerFindQuery request, CancellationToken cancellationToken)
    {
        var partners = await _service.EventPartnerService.GetAllEventPartnersByEvent(request.Id);
        return partners;
    }
}
