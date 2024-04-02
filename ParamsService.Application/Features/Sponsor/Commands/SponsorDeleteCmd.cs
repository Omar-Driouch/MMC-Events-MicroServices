using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Commands
{
    public record SponsorDeleteCmd(Guid Id):IRequest<bool>;
}
