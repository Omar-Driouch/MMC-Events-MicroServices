using EventService.Application.IRepositories;
using EventService.Domain.Entities;
using EventService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Event> _db;
        
        public EventRepository(IApplicationDbContext db) : base(db) {
            _context = db;
            _db = _context.Set<Event>();
        }

        public async Task<IEnumerable<Event>> GetEventsByProgramId(Guid Id, params Expression<Func<Event, object>>[] includes)
        {
            IQueryable<Event> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return  query.Where(e => e.ProgramId == Id);
        }
        public async Task<Event> FindEventOnlyByIdAsync(Guid Id, params Expression<Func<Event, object>>[] includes)
        {
            IQueryable<Event> query = _db;

            foreach (var item in includes)
                query = query.Include(item);

            return await query.FirstOrDefaultAsync(e => e.Id == Id) ;
        }
        
    }
}
