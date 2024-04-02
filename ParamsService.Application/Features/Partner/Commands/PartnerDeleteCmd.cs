using MediatR;

namespace MMC.Application.Features.Participant.Commands;

public record PartnerDeleteCmd(Guid Id) : IRequest<bool>;