using SpeakerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.Data
{
    public class Speaker
    {
        public Guid Id { get; private set; }
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }
        public string? Bio {  get; private set; }
        public string? Company { get; private set; }
        public string? Email { get; private set; }
        public string? PicturePath { get; private set; }
        public bool MVP { get; private set; }
        public bool MCT { get; private set; }
        public string? Description { get; private set; }
        public SpeakerSocialMedia? SpeakerSocialMedia { get; set; }
        public ICollection<EventSpeakers> EventSpeakers { get; private set; } = new List<EventSpeakers>();
    }
}
