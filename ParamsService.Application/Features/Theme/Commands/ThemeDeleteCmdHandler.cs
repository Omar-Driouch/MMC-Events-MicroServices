using MediatR;
using ParamsService.Application.Features.Sponsor.Commands;
using ParamsService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Theme.Commands
{
    public class ThemeDeleteCmdHandler:IRequestHandler<ThemeDeleteCmd , bool>
    {
        private readonly IUnitOfService _service;
        public ThemeDeleteCmdHandler(IUnitOfService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(ThemeDeleteCmd request, CancellationToken cancellationToken)
        {
            bool success = await _service.ThemeService.DeleteAsync(request.Id);
            return success;
        }
    }
}
