using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record PartnerGetDto(
        Guid Id ,
     string? Name ,
     string? Description ,
     string? Logo 
        );
    public record PartnerCreateDto(
         string? Name,
     string? Description,
     string? Logo
        );
    public record PartnerUpdateDto(
        Guid Id,
         string? Name,
     string? Description,
     string? Logo
        );
}
