using SpeakerService.Domain.Data;
using SpeakerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.IRepositories
{
    public interface ISpeakerRepository
    {
        IEnumerable<Speaker> GetAllSpeakers();
        Speaker GetSpeakerById(Guid id);
        void CreateSpeaker(Speaker speaker);
        void UpdateSpeaker(Speaker speaker);
        void DeleteSpeaker(Guid id);
        void AddEventSpeakers(EventSpeakers sessionSpeaker);
    }
}
