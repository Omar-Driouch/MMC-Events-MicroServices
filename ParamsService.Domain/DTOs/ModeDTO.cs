using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record ModeGetDto(
        Guid Id,
        string? Type
        );
    public record ModeCreateDto(
        string? Type
        );
    public record ModeUpdateDto(
        Guid Id,
        string? Type
        );
}
