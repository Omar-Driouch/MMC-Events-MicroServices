

using MMC.Application.IRepositories;
using ParamsService.Domain.Entities;
using ParamsService.Infrastructure.Data;

namespace MMC.Infrastructure.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{


    public CityRepository(MMC_Params db) : base(db) { }
}