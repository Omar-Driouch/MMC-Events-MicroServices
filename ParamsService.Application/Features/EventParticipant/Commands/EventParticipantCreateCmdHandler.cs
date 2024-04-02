using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace MMC.Application.Features.EventParticipant.Commands
{
    public class EventParticipantCreateCmdHandler : IRequestHandler<EventParticipantCreateCmd, EventParticipantCreateDto>
    {
        private readonly IUnitOfService _service;

        public EventParticipantCreateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<EventParticipantCreateDto> Handle(EventParticipantCreateCmd request, CancellationToken cancellationToken)
        {
            var EventParticipantPostDTO = new EventParticipantCreateDto(
                 request.id_Participant,
                 request.id_Event
            );

            var partner = await _service.EventParticipantService.CreateAsync(EventParticipantPostDTO);
            return partner;
        }
    }
}
