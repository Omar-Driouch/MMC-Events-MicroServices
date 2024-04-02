using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Features.Session.Commands
{
    public record SessionDeleteCmd(Guid Id) : IRequest<bool>;
}
