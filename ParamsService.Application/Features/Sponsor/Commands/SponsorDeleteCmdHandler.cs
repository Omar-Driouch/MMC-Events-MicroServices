using MediatR;
using MMC.Application.Features.Participant.Commands;
using ParamsService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Commands
{
    public class SponsorDeleteCmdHandler:IRequestHandler<SponsorDeleteCmd , bool>
    {
        private readonly IUnitOfService _service;
        public SponsorDeleteCmdHandler(IUnitOfService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(SponsorDeleteCmd request, CancellationToken cancellationToken)
        {
            bool success = await _service.SponsorService.DeleteAsync(request.Id);
            return success;
        }
    }
}
