using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Domain.DTOs
{

    public record SessionGetDTO
    (
        Guid Id,
        string Name,
        int NumPlace,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate,
        Event Event
        
    );
    public record SessionOnlyGetDTO
    (
        Guid Id,
        string Name,
        int NumPlace,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate

    );


    public record SessionPostDTO
    (
        string Name,
        int NumPlace,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid EventId,
        Guid ModeId
    );

    public record SessionPutDTO
    (
        Guid Id,
        string Name,
        int NumPlace,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid EventId,
        Guid ModeId
    );
}
