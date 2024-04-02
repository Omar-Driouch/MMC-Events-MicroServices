using ParamsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record ParticipantGetDto(
     Guid Id ,
     string? FirstName, 
     string? LastName ,
     string? Email ,
     string? Phone ,
     string? Gender ,
     string City

        );
    public record ParticipantCreateDto(
        string? FirstName,
     string? LastName,

     string? Email,
     string? Phone,
     string? Gender,
     string City
        );
    public record ParticipantUpdateDto(
          Guid Id,
     string? FirstName,
     string? LastName,
     string? Email,
     string? Phone,
     string? Gender,
     string City
        );
}
