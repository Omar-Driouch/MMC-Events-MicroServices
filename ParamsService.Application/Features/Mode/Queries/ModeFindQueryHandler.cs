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
    public class ModeFindQueryHandler : IRequestHandler<ModeFindQuery, ModeGetDto>
    {

        private readonly IUnitOfService _service;
        public ModeFindQueryHandler(IUnitOfService service)
        {
            _service = service;
        }
        public async Task<ModeGetDto> Handle(ModeFindQuery request , CancellationToken cancellationToken)
        {
            var mode = await _service.ModeService.FindAsync(request.Id);
            return mode;
        }
    }

 }
