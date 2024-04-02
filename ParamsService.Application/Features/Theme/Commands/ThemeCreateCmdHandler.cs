using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Theme.Commands
{
    public class ThemeCreateCmdHandler:IRequestHandler<ThemeCreateCmd , ThemeGetDto>
    {
        private readonly IUnitOfService _service;
        public ThemeCreateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<ThemeGetDto> Handle(ThemeCreateCmd request , CancellationToken cancellationToken)
        {
            var themeCreateDto = new ThemeCreateDto(
                  request.Name
                );

            var theme = await _service.ThemeService.CreateAsync( themeCreateDto );
            return theme;
        }
    }
}
