using MediatR;
using MMC.Application.Features.Partner.Commands;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Commands
{
    public class SponsorUpdateCmdHandler:IRequestHandler<SponsorUpdateCmd, SponsorGetDto>
    {

        private readonly IUnitOfService _service;
        public SponsorUpdateCmdHandler(IUnitOfService service)
        {
            _service  = service;
        }

        public async Task<SponsorGetDto> Handle(SponsorUpdateCmd request, CancellationToken cancellationToken)
        {
            var sponsorPutDTO = new SponsorUpdateDto(
                request.Id,
                request.Name,
                 request.Description,
                 request.Logo
                );
            var sponsor = await _service.SponsorService.UpdateAsync(sponsorPutDTO);
            return sponsor;
        }

    }
}
