using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventParticipant.Queries;

public record EventParticipantFindAllQuery : IRequest<IEnumerable<EventParticipantGetDto>>;