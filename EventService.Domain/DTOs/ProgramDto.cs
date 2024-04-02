using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Domain.DTOs
{
    public record ProgramGetDTO
    (
        Guid Id,
        string Title,
        ICollection<Event>? Events
    );
    public record ProgramOnlyGetDTO
    (
        Guid Id,
        string Title
    );

    public record ProgramPostDTO
    (
            string Title
    );
    

    public record ProgramPutDTO
    (
        Guid Id,
        string Title
    );
}
