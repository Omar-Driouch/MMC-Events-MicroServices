using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IThemeService
    {
        Task<ThemeGetDto> FindAsync(Guid id);
        Task<IEnumerable<ThemeGetDto>> FindAllAsync();
        Task<ThemeGetDto> CreateAsync(ThemeCreateDto ParticipantPostDTO);
        Task<ThemeGetDto> UpdateAsync(ThemeUpdateDto ParticipantPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}