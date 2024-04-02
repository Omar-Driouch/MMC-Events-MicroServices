using MediatR;
using ParamsService.Application.Features.Sponsor.Commands;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Theme.Commands
{
    public class ThemeUpdateCmdHandler:IRequestHandler<ThemeUpdateCmd , ThemeGetDto>
    {
        private readonly IUnitOfService _service;
        public ThemeUpdateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<ThemeGetDto> Handle(ThemeUpdateCmd request, CancellationToken cancellationToken)
        {
            var themePutDTO = new ThemeUpdateDto(
                request.Id,
                request.Name
                );
            var theme = await _service.ThemeService.UpdateAsync(themePutDTO);
            return theme;
        }
    }
}
