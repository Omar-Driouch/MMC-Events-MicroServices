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
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly SpeakerDBContext _dbContext;

        public SpeakerRepository(SpeakerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return _dbContext.Speakers.Include(s => s.SpeakerSocialMedia).ToList();
        }

        public Speaker GetSpeakerById(Guid id)
        {
            var speaker = _dbContext.Speakers
                            .Include(s => s.SpeakerSocialMedia)
                            .FirstOrDefault(s => s.Id == id);
            return speaker;
        }

        public void CreateSpeaker(Speaker speaker)
        {
            _dbContext.Speakers.Add(speaker);
            _dbContext.SaveChanges();
        }

        public void UpdateSpeaker(Speaker speaker)
        {
            _dbContext.Speakers.Update(speaker);
            _dbContext.SaveChanges();
        }

        public void DeleteSpeaker(Guid id)
        {
            var speaker = _dbContext.Speakers.FirstOrDefault(s => s.Id == id);
            if (speaker != null)
            {
                _dbContext.Speakers.Remove(speaker);
                _dbContext.SaveChanges();
            }
        }

        public void AddEventSpeakers(EventSpeakers sessionSpeaker)
        {
            _dbContext.EventSpeakers.Add(sessionSpeaker);
            _dbContext.SaveChanges();
        }

    }
}
