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
    public class ThemeFindQueryHandler:IRequestHandler<ThemeFindQuery , ThemeGetDto>
    {
        private readonly IUnitOfService _service;
        public ThemeFindQueryHandler(IUnitOfService service) => _service = service;




        public async Task<ThemeGetDto> Handle(ThemeFindQuery request, CancellationToken cancellationToken)
        {
            var theme = await _service.ThemeService.FindAsync(request.Id);
            return theme;
        }
    }
}
