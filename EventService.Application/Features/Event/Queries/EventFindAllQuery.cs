using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Queries;

public record EventFindAllQuery : IRequest<IEnumerable<EventGetDTO>>;