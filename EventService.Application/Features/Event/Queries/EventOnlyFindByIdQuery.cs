using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Event.Queries
{

    public record EventOnlyFindByIdQuery(Guid Id) : IRequest<EventOnlyGetDTO>;
}
