using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Program.Commands;

public record ProgramCreateCmd(string Title) : IRequest<ProgramGetDTO>;