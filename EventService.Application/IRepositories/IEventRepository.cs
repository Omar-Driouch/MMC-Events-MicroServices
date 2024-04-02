using EventService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByProgramId(Guid Id, params Expression<Func<Event, object>>[] includes);

        Task<Event> FindEventOnlyByIdAsync(Guid Id, params Expression<Func<Event, object>>[] includes);

    }
}
