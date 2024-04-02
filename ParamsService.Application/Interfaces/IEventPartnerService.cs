using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IEventPartnerService
    {
        Task<IEnumerable<PartnerGetDto>> GetAllEventPartnersByEvent(Guid id);
        Task<IEnumerable<EventPartnerGetDto>> FindAllAsync();
        Task<EventPartnerCreateDto> CreateAsync(EventPartnerCreateDto EventPartnerPostDTO);
        Task<EventPartnerGetDto> UpdateAsync(PartnerUpdateDto ParticipantPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}