using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Mode.Commands
{
    public class ModeCreateCmdHandler:IRequestHandler<ModeCreateCmd , ModeGetDto>
    {
        private readonly IUnitOfService _service;
        public ModeCreateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }
        public async Task<ModeGetDto> Handle(ModeCreateCmd request , CancellationToken cancellationToken)
        {
            var modeCreateDto = new ModeCreateDto(request.Type);
            var mode = await _service.ModeService.CreateAsync(modeCreateDto);
            return mode;
        }
    }
}
