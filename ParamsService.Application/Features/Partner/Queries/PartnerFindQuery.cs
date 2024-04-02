using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Queries;

public record PartnerFindQuery(Guid Id) : IRequest<PartnerGetDto>;