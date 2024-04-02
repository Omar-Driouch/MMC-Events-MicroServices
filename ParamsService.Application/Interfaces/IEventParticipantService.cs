using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IEventParticipantService
    {
        Task<IEnumerable<ParticipantGetDto>> GetAllEventParticipantByEvent(Guid id);
        Task<IEnumerable<EventParticipantGetDto>> FindAllAsync();
        Task<EventParticipantCreateDto> CreateAsync(EventParticipantCreateDto EventPartnerPostDTO);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(EventParticipantUpdateDto EventParticipantPostDTO);
    }
}