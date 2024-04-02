
using MMC.Application.IRepositories;
using ParamsService.Infrastructure.Data;
using ParamsService.Domain.Entities;

namespace MMC.Infrastructure.Repositories;

public class ModeRepository : Repository<Mode>, IModeRepository
{
    public ModeRepository(MMC_Params db) : base(db) { }
}