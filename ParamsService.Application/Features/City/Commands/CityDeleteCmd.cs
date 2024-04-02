using MediatR;

namespace MMC.Application.Features.City.Commands;

public record CityDeleteCmd(Guid Id) : IRequest<bool>;