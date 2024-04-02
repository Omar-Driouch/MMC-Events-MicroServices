using Microsoft.EntityFrameworkCore;
using SpeakerService.Domain.Data;
using SpeakerService.Domain.Entities;
using SpeakerService.Domain.IRepositories;
using SpeakerService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Infrastructure.Repositories
{
    public class EventSpeakersRepository : IEventSpeakersRepository
    {
        private readonly SpeakerDBContext _dbContext;


        public EventSpeakersRepository(SpeakerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateEventSpeaker(EventSpeakers eventSpeakers)
        {
            var tt =  _dbContext.EventSpeakers.AddAsync(eventSpeakers);
            var issaved = _dbContext.SaveChanges();
            return issaved > 0;
        }

       

        public bool DeleteSpeakerFromEvent(Guid Speakersid)
        {
            var all = _dbContext.EventSpeakers.Where(sp=> sp.SpeakerId == Speakersid).ToList();
            if (all != null)
            {
                _dbContext.EventSpeakers.RemoveRange(all);
            }
            var issaved = _dbContext.SaveChanges();
            return issaved > 0;
        }

        public IEnumerable<EventSpeakers> GetAllEvenetsManagedBySpeaker(Guid SpeakerID)
        {
            return _dbContext.EventSpeakers.Where(es => es.SpeakerId == SpeakerID).ToList();
        }


        public IEnumerable<EventSpeakers> GetAllSpeakersOfAnEvent(Guid EventID)
        {
            return _dbContext.EventSpeakers.Where(es => es.EventId == EventID).ToList();
        }


        public bool DeleteEventFromSpeakerEvent(Guid EventID)
        {
            var eventSpeakersToDelete = _dbContext.EventSpeakers.Where(es => es.EventId == EventID).ToList();

            if (eventSpeakersToDelete.Count > 0)
            {
                _dbContext.EventSpeakers.RemoveRange(eventSpeakersToDelete);
                _dbContext.SaveChanges(); 
                return true;
            }
            else
            {
                return false;
            }
        }

         
 
    }
}
