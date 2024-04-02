using MediatR;
using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Features.Sponsor.Commands
{
    public record SponsorCreateCmd(
      string? Name,
      string? Description,
      string? Logo) : IRequest<SponsorGetDto>;
}
