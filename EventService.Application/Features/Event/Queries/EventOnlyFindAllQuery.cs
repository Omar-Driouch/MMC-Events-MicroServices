using EventService.Domain.DTOs;
using MediatR;



namespace EventService.Application.Features.Event.Queries;

public record EventOnlyFindAllQuery : IRequest<IEnumerable<EventOnlyGetDTO>>;