using MediatR;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.City.Commands;

public record CityCreateCmd(string Name) : IRequest<CityGetDto>;