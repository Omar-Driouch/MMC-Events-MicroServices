using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.Data
{
    public class SpeakerSocialMedia
    {
        public Guid Id { get; set; }
        public Guid SpeakerId { get; set; }
        public string? Linkedin { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? X { get; set; }
        public Speaker Speaker { get; set; }
    }
}
