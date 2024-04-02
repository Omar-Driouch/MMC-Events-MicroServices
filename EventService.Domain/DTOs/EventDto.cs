using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Domain.DTOs
{

    public record EventGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImagePath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId, 
        Guid ProgramId,
        ProgramGetDTO Program,
        ICollection<SessionGetDTO>   Sessions,
        Guid ThemeId

    );

    public record EventOnlyGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImagePath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ProgramId,
        Guid ThemeId

    );

    public record EventPostDTO
    (
        string Title,
        string? Address,
        string? Description,
        string? ImagePath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );

    public record EventPutDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImagePath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );
}
