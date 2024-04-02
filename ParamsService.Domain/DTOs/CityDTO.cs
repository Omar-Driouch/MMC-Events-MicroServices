using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record CityGetDto(
        Guid Id,
        string Name
        //ICollection<ParticipantGetDto> Participants
        );
    public record CityCreateDto(
        string Name
        );
    public record CityUpdateDto(
        Guid Id,
        string Name
        );
    
}
