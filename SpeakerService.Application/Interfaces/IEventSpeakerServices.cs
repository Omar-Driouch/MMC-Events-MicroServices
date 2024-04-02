using SpeakerService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.Interfaces
{
    public interface IEventSpeakerServices
    {
        
        
        bool CreateEventSpeaker(EventSpeakersDto eventSpeakersDto);
        bool DeleteSpeakerFromEvent(Guid SpeakerID);
        bool DeleteEventFromSpeakerEvent(Guid EventID);
        IEnumerable<GSpeakerDto> GetAllSpeakersOfAnEvenet(Guid EventID);
        IEnumerable<EventDto> GetAllEvenetsManagedBySpeaker(Guid SpeakerID);
      


    }
}
