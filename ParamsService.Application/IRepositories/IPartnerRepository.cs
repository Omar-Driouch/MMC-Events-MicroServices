
using ParamsService.Domain.Entities;

namespace MMC.Application.IRepositories;

public interface IPartnerRepository : IRepository<Partner>
{
    Task<bool> DeleteEventPartnerbyPartnerID(Guid id_partner);
}