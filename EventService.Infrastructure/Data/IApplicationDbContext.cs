using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        
        DbSet<Event> Events { get; set; }
        DbSet<Program> Programs{ get; set; }
        DbSet <Session> Sessions { get; set; }      

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
