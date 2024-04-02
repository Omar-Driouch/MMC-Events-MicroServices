using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.EventParticipant.Queries;

public record EventParticipantFindQuery(Guid Id) : IRequest<IEnumerable<ParticipantGetDto>>;

