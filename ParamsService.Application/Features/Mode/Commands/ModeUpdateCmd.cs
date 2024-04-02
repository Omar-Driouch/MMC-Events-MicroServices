using MediatR;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Mode.Commands
{
    public record ModeUpdateCmd(Guid Id , string? Type ):IRequest<ModeGetDto>;
}
