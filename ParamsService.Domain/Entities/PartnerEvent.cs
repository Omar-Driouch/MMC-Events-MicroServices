using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Domain.Entities
{
    public class PartnerEvent
    {
        public Guid Id { get; set; }
        public Guid PartnerId { get; set; }
        public Guid EventId { get; set;}
    }
}
