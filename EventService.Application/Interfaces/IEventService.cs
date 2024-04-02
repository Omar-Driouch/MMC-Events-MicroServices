using EventService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventGetDTO> FindAsync(Guid id);
        Task<IEnumerable<EventGetDTO>> FindAllAsync();
        Task<IEnumerable<EventOnlyGetDTO>> FindAllEventOnlyAsync();
        Task<EventOnlyGetDTO> FindEventOnlyByIdAsync(Guid id);

        Task<EventGetDTO> CreateAsync(EventPostDTO eventPostDTO);
        Task<EventGetDTO> UpdateAsync(EventPutDTO eventPutDTO);
        Task<IEnumerable<EventGetDTO>> FindAllByProgramIdAsync(Guid Id);
        Task<bool> DeleteAsync(Guid id);
    }
}
