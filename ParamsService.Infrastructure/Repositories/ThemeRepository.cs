
using MMC.Application.IRepositories;
using ParamsService.Domain.Entities;
using ParamsService.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class ThemeRepository : Repository<Theme>, IThemeRepository
{ 
    public ThemeRepository(MMC_Params db) : base(db) { }
}