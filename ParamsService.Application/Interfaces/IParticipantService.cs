using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IParticipantService
    {
        Task<ParticipantGetDto> FindAsync(Guid id);
        Task<IEnumerable<ParticipantGetDto>> FindAllAsync();
        Task<ParticipantGetDto> CreateAsync(ParticipantCreateDto ParticipantPostDTO);
        Task<ParticipantGetDto> UpdateAsync(ParticipantUpdateDto ParticipantPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}