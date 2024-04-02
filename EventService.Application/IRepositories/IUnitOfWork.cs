using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.IRepositories
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }
        ISessionRepository SessionRepository { get; }
        IProgramRepository ProgramRepository { get; }
        Task<int> CompleteAsync();
    }
}
