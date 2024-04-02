using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record EventPartnerGetDto(
       Guid Id,
       Guid EventId,
       Guid PartnerId
       );
    public record EventPartnerCreateDto(
        Guid PartnerId,
        Guid EventId
        );
    public record EventPartnerUpdateDto(
       Guid Id,
       Guid EventId,
       Guid PartnerId
        );
}
