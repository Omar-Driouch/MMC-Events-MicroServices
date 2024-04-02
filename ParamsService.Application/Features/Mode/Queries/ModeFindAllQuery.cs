using MediatR;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Mode.Queries
{
    public record ModeFindAllQuery():IRequest<IEnumerable<ModeGetDto>>;
}
