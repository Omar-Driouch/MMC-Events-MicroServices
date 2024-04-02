using ParamsService.Application.IRepositories;

namespace MMC.Application.IRepositories;

public interface IUnitOfWork
{
    ICityRepository CityRepository { get; }
  
    IModeRepository ModeRepository { get; }
    IParticipantRepository ParticipantRepository { get; }
    IPartnerRepository PartnerRepository { get; }

    IPartnerEventRepository EventPartnerRepository { get; }
    ISponsorRepository SponsorRepository { get; }
    IThemeRepository ThemeRepository { get; }

    IParticipantEventRepository ParticipantEventRepository { get; }

    Task<int> CompleteAsync();

     
}