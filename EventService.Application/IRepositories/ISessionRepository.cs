using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.IRepositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<IEnumerable<Session>> GetSessionByEventId(Guid Id, params Expression<Func<Session, object>>[] includes);
        Task<IEnumerable<Session>> FindAllSession( params Expression<Func<Session, object>>[] includes);



    }
}
