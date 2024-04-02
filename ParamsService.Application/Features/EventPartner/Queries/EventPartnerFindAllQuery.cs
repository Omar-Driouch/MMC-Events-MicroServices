using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventPartner.Queries;

public record EventPartnerFindAllQuery : IRequest<IEnumerable<EventPartnerGetDto>>;