using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace MMC.Application.Features.EventPartner.Commands
{
    public class EventPartnerCreateCmdHandler : IRequestHandler<EventPartnerCreateCmd, EventPartnerCreateDto>
    {
        private readonly IUnitOfService _service;

        public EventPartnerCreateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<EventPartnerCreateDto> Handle(EventPartnerCreateCmd request, CancellationToken cancellationToken)
        {
            var EventPartnerPostDTO = new EventPartnerCreateDto(
                 request.id_Partner,
                 request.id_Event
            );

            var partner = await _service.EventPartnerService.CreateAsync(EventPartnerPostDTO);
            return partner;
        }
    }
}
