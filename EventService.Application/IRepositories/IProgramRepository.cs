using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.IRepositories
{
    public interface IProgramRepository : IRepository<Program>
    {
        Task<IEnumerable<Program>> FindAllProgramOnly(params Expression<Func<Program, object>>[] includes);


    }
}
