using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface ICityService
    {
        Task<CityGetDto> FindAsync(Guid id);
        Task<IEnumerable<CityGetDto>> FindAllAsync();
        Task<CityGetDto> CreateAsync(CityCreateDto cityPostDTO);
        Task<CityGetDto> UpdateAsync(CityUpdateDto cityPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}