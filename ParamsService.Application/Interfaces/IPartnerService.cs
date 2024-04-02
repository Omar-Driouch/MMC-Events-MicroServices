using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Interfaces
{
    public interface IPartnerService
    {
        Task<PartnerGetDto> FindAsync(Guid id);
        Task<IEnumerable<PartnerGetDto>> FindAllAsync();
        Task<PartnerGetDto> CreateAsync(PartnerCreateDto ParticipantPostDTO);
        Task<PartnerGetDto> UpdateAsync(PartnerUpdateDto ParticipantPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}