using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record SponsorGetDto(
        Guid Id ,
     string? Name ,
     string? Description ,
     string? Logo 
        );
    public record SponsorCreateDto(
         string? Name,
     string? Description,
     string? Logo
        );
    public record SponsorUpdateDto(
        Guid Id,
         string? Name,
     string? Description,
     string? Logo
        );
}
