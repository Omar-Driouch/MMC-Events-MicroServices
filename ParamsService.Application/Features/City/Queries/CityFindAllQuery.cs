using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Queries;

public record CityFindAllQuery : IRequest<IEnumerable<CityGetDto>>;