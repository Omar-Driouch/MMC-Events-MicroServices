using MediatR;

namespace EventService.Application.Features.Event.Commands;

public record EventDeleteCmd(Guid Id) : IRequest<bool>;