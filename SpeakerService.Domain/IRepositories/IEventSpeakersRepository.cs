using SpeakerService.Domain.Data;
using SpeakerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.IRepositories
{
    public interface IEventSpeakersRepository
    {

       bool CreateEventSpeaker(EventSpeakers eventSpeakers);
       bool DeleteSpeakerFromEvent(Guid Speakersid);
       bool DeleteEventFromSpeakerEvent(Guid EventID);

       IEnumerable<EventSpeakers> GetAllSpeakersOfAnEvent(Guid EventID);
       IEnumerable<EventSpeakers> GetAllEvenetsManagedBySpeaker(Guid SpeakerID);
        

    }
}
