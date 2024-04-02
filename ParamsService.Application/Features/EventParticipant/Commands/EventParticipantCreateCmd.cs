using MediatR;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.EventParticipant.Commands;

public record EventParticipantCreateCmd(
     Guid id_Participant,
     Guid id_Event)
     : IRequest<EventParticipantCreateDto>;