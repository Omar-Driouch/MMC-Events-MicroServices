using MediatR;

namespace EventService.Application.Features.Program.Commands;

public record ProgramDeleteCmd(Guid Id) : IRequest<bool>;