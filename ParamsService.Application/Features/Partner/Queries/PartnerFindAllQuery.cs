using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Queries;

public record PartnerFindAllQuery : IRequest<IEnumerable<PartnerGetDto>>;