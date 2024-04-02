
using Microsoft.EntityFrameworkCore;
using MMC.Application.IRepositories;
using ParamsService.Domain.Entities;
using ParamsService.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class PartnerRepository : Repository<Partner>, IPartnerRepository
{
    private readonly MMC_Params _db;
    public PartnerRepository(MMC_Params db) : base(db) {

        _db = db;
    }

    public async Task<bool> DeleteEventPartnerbyPartnerID(Guid id_partner)
    {
        var EventPartner = await _db.PartnerEvent.Where(Ep => Ep.PartnerId == id_partner).ToListAsync();
        if (EventPartner != null)
        {
            _db.PartnerEvent.RemoveRange(EventPartner);
            var saved = await _db.SaveChangesAsync();
            return saved > 0;
        }
        else { return false; }



    }
}