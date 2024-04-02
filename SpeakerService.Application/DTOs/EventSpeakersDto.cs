using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.DTOs
{
    public class EventSpeakersDto
    {
        public Guid EventId { get; set; }
        public Guid SpeakerId { get; set; }

       
    }
}
