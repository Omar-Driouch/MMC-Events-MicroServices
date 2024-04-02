using EventService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Interfaces
{
    public interface ISessionService
    {
        Task<SessionGetDTO> FindAsync(Guid id);
        Task<IEnumerable<SessionGetDTO>> FindAllAsync();
        Task<SessionGetDTO> CreateAsync(SessionPostDTO sessionPostDTO);
        Task<SessionGetDTO> UpdateAsync(SessionPutDTO sessionPutDTO);
        Task<IEnumerable<SessionGetDTO>> FindAllByEventIdAsync(Guid Id);
        Task<IEnumerable<SessionOnlyGetDTO>> FindAllSession();
        Task<SessionOnlyGetDTO> FindSessionOnlyByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);

    }
}
