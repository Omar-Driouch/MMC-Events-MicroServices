using EventService.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Features.Event.Queries
{
    public record EventFindAllByProgramIdQuery(Guid Id) : IRequest<IEnumerable<EventGetDTO>>;
}
