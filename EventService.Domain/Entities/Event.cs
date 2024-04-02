using EventService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace EventService.Domain.Entities
{

    public class Event
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Address { get; private set; }
        public string? Description { get; private set; }
        public string? ImagePath { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public Guid CityId { get; private set; }

        public Guid? ProgramId { get; private set; } = null;
        public Program? Program { get; private set; }
        public Guid? ThemeId { get; private set; }
        

        public ICollection<Session>? Sessions { get; private set; }
        




        public Event(string title, string? address, string? description, string? imagePath, DateTime? startDate, DateTime? endDate, Guid cityId, Guid? themeId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Address = address;
            Description = description;
            ImagePath = imagePath;
            StartDate = startDate;
            EndDate = endDate;
            CityId = cityId;
            ThemeId = themeId;
        }
    }
}
