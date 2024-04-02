using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record EventParticipantGetDto(
       Guid Id,
       Guid Id_Event,
       Guid id_Participant
       );
    public record EventParticipantCreateDto(
        Guid id_Participant,
        Guid Id_Event
        );

    public record EventParticipantUpdateDto(
       Guid id_Participant,
       Guid Id_Event,
       bool IsParticipated 
       );
}
