using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface ISponsorService
    {
        Task<SponsorGetDto> FindAsync(Guid id);
        Task<IEnumerable<SponsorGetDto>> FindAllAsync();
        Task<SponsorGetDto> CreateAsync(SponsorCreateDto ParticipantPostDTO);
        Task<SponsorGetDto> UpdateAsync(SponsorUpdateDto ParticipantPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}