using EventService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Interfaces
{
    public interface IProgramService
    {
        Task<ProgramGetDTO> FindAsync(Guid id);
        Task<IEnumerable<ProgramGetDTO>> FindAllAsync();
        Task<IEnumerable<ProgramOnlyGetDTO>> FindAllProgramOnly();
        Task<ProgramOnlyGetDTO> FindProgramOnlyAsync(Guid id);
        Task<ProgramGetDTO> CreateAsync(ProgramPostDTO eventPostDTO);
        Task<ProgramGetDTO> UpdateAsync(ProgramPutDTO eventPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
