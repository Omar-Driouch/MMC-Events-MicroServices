using MediatR;

namespace MMC.Application.Features.Participant.Commands;

public record ParticipantDeleteCmd(Guid Id) : IRequest<bool>;