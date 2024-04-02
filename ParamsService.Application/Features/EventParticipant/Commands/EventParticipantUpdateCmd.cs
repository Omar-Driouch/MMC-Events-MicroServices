using MediatR;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Features.EventParticipant.Commands
{
    public record EventParticipantUpdateCmd(EventParticipantUpdateDto Id) : IRequest<EventParticipantUpdateDto>;

}
