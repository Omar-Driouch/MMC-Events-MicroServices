using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Participant.Queries;

public record ParticipantFindQuery(Guid Id) : IRequest<ParticipantGetDto>;