using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Queries;

public record EventFindQuery(Guid Id) : IRequest<EventGetDTO>;