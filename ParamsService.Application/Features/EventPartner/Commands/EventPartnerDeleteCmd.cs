using MediatR;

namespace MMC.Application.Features.EventPartner.Commands;

public record EventPartnerDeleteCmd(Guid Id) : IRequest<bool>;