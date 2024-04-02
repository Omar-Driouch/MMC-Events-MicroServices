using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Features.EventParticipant.Commands
{
    public class EventParticipantUpdateCmdHandler : IRequestHandler<EventParticipantUpdateCmd, EventParticipantUpdateDto>
    {
        private readonly IUnitOfService _service;
        public EventParticipantUpdateCmdHandler(IUnitOfService service)
        {
            _service = service;
        }

        public async Task<EventParticipantUpdateDto> Handle(EventParticipantUpdateCmd request, CancellationToken cancellationToken)
        {
            var updateDto = new EventParticipantUpdateDto(
                request.Id.id_Participant,
                request.Id.Id_Event,
                request.Id.IsParticipated
            );
            var mode = await _service.EventParticipantService.UpdateAsync(updateDto);
            if (mode)
            {
                return updateDto;
            }
            else
            {
                return null;
            }
           
        }
    }

}
