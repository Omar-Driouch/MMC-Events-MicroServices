using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Program.Commands;

public record ProgramUpdateCmd(Guid Id,
        string Title)
    : IRequest<ProgramGetDTO>;