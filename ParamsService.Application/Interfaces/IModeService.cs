using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IModeService
    {
        Task<ModeGetDto> FindAsync(Guid id);
        Task<IEnumerable<ModeGetDto>> FindAllAsync();
        Task<ModeGetDto> CreateAsync(ModeCreateDto modePostDTO);
        Task<ModeGetDto> UpdateAsync(ModeUpdateDto modePutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}