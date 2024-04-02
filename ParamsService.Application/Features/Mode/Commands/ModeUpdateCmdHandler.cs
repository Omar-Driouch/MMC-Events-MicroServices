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
    public class ModeUpdateCmdHandler:IRequestHandler<ModeUpdateCmd , ModeGetDto>
    {
        private readonly IUnitOfService _service;
        public ModeUpdateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<ModeGetDto> Handle(ModeUpdateCmd request , CancellationToken cancellationToken)
        {
            var modeUpdateDto = new ModeUpdateDto(request.Id, request.Type);
            var mode = await _service.ModeService.UpdateAsync(modeUpdateDto);
                return mode;
        }
    }
}
