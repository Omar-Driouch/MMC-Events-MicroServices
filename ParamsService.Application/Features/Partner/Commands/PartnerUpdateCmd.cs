using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Partner.Commands;

public record PartnerUpdateCmd(Guid Id,
    string? Name,
     string? Description,
     string? Logo) : IRequest<PartnerGetDto>;