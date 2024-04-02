using MediatR;
using ParamsService.Application.Features.Sponsor.Queries;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Theme.Queries
{
    public class ThemeFindAllQueryHandler:IRequestHandler<ThemeFindAllQuery  ,IEnumerable<ThemeGetDto>>
    {
        private readonly IUnitOfService _service;
        public ThemeFindAllQueryHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<ThemeGetDto>> Handle(ThemeFindAllQuery request, CancellationToken cancellationToken)
        {
            var themes = await _service.ThemeService.FindAllAsync();
            return themes;
        }
    }
}
