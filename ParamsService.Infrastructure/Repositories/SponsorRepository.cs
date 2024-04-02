
using MMC.Application.IRepositories;
using ParamsService.Domain.Entities;
using ParamsService.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class SponsorRepository : Repository<Sponsor>, ISponsorRepository
{ 
    public SponsorRepository(MMC_Params db) : base(db) { }
}