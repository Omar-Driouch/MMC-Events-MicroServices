using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.Entities
{
    public class SponsorEvent
    {
        public Guid SponsorId { get; set; }
        public Guid EventId { get; set;}
    }
}
