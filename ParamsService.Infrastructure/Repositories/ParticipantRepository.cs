 
using MMC.Application.IRepositories;
using ParamsService.Infrastructure.Data;
using ParamsService.Domain.Entities;

namespace MMC.Infrastructure.Repositories;

public class ParticipantRepository : Repository<Participant>, IParticipantRepository
{
    public ParticipantRepository(MMC_Params db) : base(db) { }
}