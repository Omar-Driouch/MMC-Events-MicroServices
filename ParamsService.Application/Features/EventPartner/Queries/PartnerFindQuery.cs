using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventPartner.Queries;

public record EventPartnerFindQuery(Guid Id) : IRequest<IEnumerable<PartnerGetDto>>;
