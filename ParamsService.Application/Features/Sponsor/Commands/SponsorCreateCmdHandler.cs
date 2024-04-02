using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
namespace ParamsService.Application.Features.Sponsor.Commands
{
    public class SponsorCreateCmdHandler : IRequestHandler<SponsorCreateCmd, SponsorGetDto>
    {
        private readonly IUnitOfService _service;
        public SponsorCreateCmdHandler(IUnitOfService service) => _service = service;

        public async Task<SponsorGetDto> Handle(SponsorCreateCmd request, CancellationToken cancellationToken)
        {
            var sponsorPostDTO = new SponsorCreateDto(
                 request.Name,
                 request.Description,
                 request.Logo
                );
            var sponsor = await _service.SponsorService.CreateAsync(sponsorPostDTO);
            return sponsor;
        }
    }
}
