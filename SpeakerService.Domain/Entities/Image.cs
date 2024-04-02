using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Domain.Entities
{
    public class Imagee
    {
        [Key]
        public Guid? Id { get; set; }
        public Guid? TheId { get; set; }
        public Byte[]? ByteImage { get; set; }
        [NotMapped]
        public IFormFile? File {  get; set; }
    }
}
