using SpeakerService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.Interfaces
{
    public interface ISpeakerService
    {
        IEnumerable<GSpeakerDto> GetAllSpeakers();
        GSpeakerDto GetSpeakerById(Guid id);
        void CreateSpeaker(CSpeakerDto speakerDto);
        void UpdateSpeaker(GSpeakerDto speakerDto);
        void DeleteSpeaker(Guid id);
        
    }
}
