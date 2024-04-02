using SpeakerService.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.Entities
{
    public class EventSpeakers
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid SpeakerId { get; set; }
        
    }
}
