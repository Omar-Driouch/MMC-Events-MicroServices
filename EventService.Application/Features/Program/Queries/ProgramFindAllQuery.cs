using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Program.Queries;

public record ProgramFindAllQuery : IRequest<IEnumerable<ProgramGetDTO>>;