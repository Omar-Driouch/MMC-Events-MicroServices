using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Queries;

public record CityFindQuery(Guid Id) : IRequest<CityGetDto>;