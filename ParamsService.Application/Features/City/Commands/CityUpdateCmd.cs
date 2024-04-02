using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Commands;

public record CityUpdateCmd(Guid Id, string Name) : IRequest<CityGetDto>;