using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Interfaces
{
    public interface IUnitOfService
    {
        ICityService CityService { get; }
        IModeService ModeService { get; }
        IParticipantService ParticipantService { get; }
        IPartnerService PartnerService { get; }
     
        ISponsorService SponsorService { get; }
        IThemeService ThemeService { get; }

        IEventPartnerService EventPartnerService { get; }
        IEventParticipantService EventParticipantService { get; }

    }
}
