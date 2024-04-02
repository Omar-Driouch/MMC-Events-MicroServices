using System.Threading.Tasks;
using MMC.Application.IRepositories;
using ParamsService.Application.IRepositories;
using ParamsService.Infrastructure.Data;
using ParamsService.Infrastructure.Repositories;

namespace MMC.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMC_Params _db;

        public ICityRepository CityRepository { get; private set; }
        public IModeRepository ModeRepository { get; private set; }
        public IParticipantRepository ParticipantRepository { get; private set; }
        public IPartnerRepository PartnerRepository { get; private set; }

        public ISponsorRepository SponsorRepository { get; private set; }
        public IThemeRepository ThemeRepository { get; private set; }

        public IParticipantEventRepository ParticipantEventRepository { get; private set; }
        

        public IPartnerEventRepository EventPartnerRepository { get; private set; }

        public UnitOfWork(MMC_Params db)
        {
            _db = db;
            CityRepository = new CityRepository(_db);
            ModeRepository = new ModeRepository(_db);
            ParticipantRepository = new ParticipantRepository(_db);
            PartnerRepository = new PartnerRepository(_db);
            SponsorRepository = new SponsorRepository(_db);
            ThemeRepository = new ThemeRepository(_db);
            EventPartnerRepository = new PartnerEventRepository(_db);
            ParticipantEventRepository = new EventParticipantRepository(_db);
        }

        public async Task<int> CompleteAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
