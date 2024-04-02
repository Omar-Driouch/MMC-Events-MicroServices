using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.DTOs
{
    public record ThemeGetDto(
        Guid Id,
        string? Name
        );
    public record ThemeCreateDto(
        string? Name
        );
    public record ThemeUpdateDto(
        Guid Id,
        string? Name
        );
}
