using MediatR;
using MMC.Application.Features.Partner.Queries;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Queries
{
    public class SponsorFindQueryHandler:IRequestHandler<SponsorFindQuery , SponsorGetDto>
    {
        private readonly IUnitOfService _service;
        public SponsorFindQueryHandler(IUnitOfService service) => _service = service;




        public async Task<SponsorGetDto> Handle(SponsorFindQuery request, CancellationToken cancellationToken)
        {
            var sponsor = await _service.SponsorService.FindAsync(request.Id);
            return sponsor;
        }
    }
}
