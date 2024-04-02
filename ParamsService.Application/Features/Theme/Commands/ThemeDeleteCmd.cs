using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Theme.Commands
{
    public record ThemeDeleteCmd(Guid Id):IRequest<bool>;
}
