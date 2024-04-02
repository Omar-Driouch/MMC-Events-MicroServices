using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.DTOs
{
    public class GSpeakerDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get;  set; }
        public string Bio { get;  set; }
        public string Company { get;  set; }
        public string Email { get;  set; }
        public string PicturePath { get;  set; }
        public bool MVP { get;  set; } = false;
        public bool MCT { get;  set; } = false;
        public string Description { get;  set; }
        public CSpeakerSocialMediaDto SpeakerSocialMedia { get; set; }
    }
}
