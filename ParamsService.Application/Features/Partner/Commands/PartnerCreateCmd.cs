using MediatR;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.Partner.Commands;

public record PartnerCreateCmd(
     string? Name,
     string? Description,
     string? Logo) : IRequest<PartnerGetDto>;