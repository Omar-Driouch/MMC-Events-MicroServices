using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.Entities
{
    public class ParticipantEvent
    {
        public Guid Id { get; set; }
        public Guid Id_Event { get; set;}
        public Guid Id_Participant { get; set; }
        public bool IsParticipated { get; set; } = false;
    }
}
