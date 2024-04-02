using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Queries
{
    public class SponsorFindAllQueryHandler:IRequestHandler<SponsorFindAllQuery, IEnumerable<SponsorGetDto>>
    {
        private readonly IUnitOfService _service;
        public SponsorFindAllQueryHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<SponsorGetDto>> Handle(SponsorFindAllQuery request , CancellationToken cancellationToken)
        {
            var sponsors = await _service.SponsorService.FindAllAsync();
            return sponsors;
        }
    }
}
