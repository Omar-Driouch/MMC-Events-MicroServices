using MediatR;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.EventPartner.Commands;

public record EventPartnerCreateCmd(
     Guid id_Partner,
     Guid id_Event)
     : IRequest<EventPartnerCreateDto>;