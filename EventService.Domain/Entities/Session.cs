using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Domain.Entities
{
   
public class Session
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int NumPlace { get; private set; }
    public string? Description { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public Guid EventId { get; private set; }
    public Event Event { get; private set; }

    public Guid ModeId { get; private set; }
    

   



    public Session(string name, int numPlace, string? description, DateTime? startDate, DateTime? endDate, Guid eventId, Guid modeId)
    {
        Id = Guid.NewGuid();
        Name = name;
        NumPlace = numPlace;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        EventId = eventId;
        ModeId = modeId;
    }
}
}
