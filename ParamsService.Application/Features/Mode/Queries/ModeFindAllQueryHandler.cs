using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Mode.Queries
{
    public class ModeFindAllQueryHandler:IRequestHandler<ModeFindAllQuery , IEnumerable<ModeGetDto>>
    {
        private readonly IUnitOfService _service;

        public ModeFindAllQueryHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<ModeGetDto>> Handle(ModeFindAllQuery request , CancellationToken cancellationToken)
        {
            var modes = await _service.ModeService.FindAllAsync();
            return modes;
        }
    }
}
