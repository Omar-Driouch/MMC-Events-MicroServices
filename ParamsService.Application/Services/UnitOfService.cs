using AutoMapper;

using MMC.Application.IRepositories;
using ParamsService.Application.Interfaces;

namespace MMC.Application.Services;

public class UnitOfService : IUnitOfService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public ICityService CityService { get; private set; }
    public IModeService ModeService { get; private set; }
    public IPartnerService PartnerService { get; private set; }
    public IParticipantService ParticipantService { get; private set; }
    public ISponsorService SponsorService { get; private set; }
    public IThemeService ThemeService { get; private set; }
    public IEventPartnerService EventPartnerService { get; private set; }

    public IEventParticipantService EventParticipantService { get; private set; }

    public UnitOfService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
        CityService = new CityService(_uow, _map);
        ModeService = new ModeService(_uow, _map);
        PartnerService = new PartnerService(_uow, _map);
        ParticipantService = new ParticipantService(_uow, _map);
        SponsorService = new SponsorService(_uow, _map);
        ThemeService = new ThemeService(_uow, _map);

        EventPartnerService = new EventPartnerService(_uow, _map);
        EventParticipantService = new EventParticipantService(_uow, _map);
    }
}