using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeakerService.Domain.Entities;
using SpeakerService.Infrastructure.Data;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;

namespace SpeakerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imagesController : ControllerBase
    {
        private readonly SpeakerDBContext _dbContext;
        public imagesController(SpeakerDBContext speakerDBContext)
        {
            _dbContext = speakerDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] Imagee model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("File is required");

            using (var memoryStream = new MemoryStream())
            {
                await model.File.CopyToAsync(memoryStream);
                model.ByteImage = memoryStream.ToArray();
            }

            _dbContext.Imagess.Add(model);
            await _dbContext.SaveChangesAsync();

            return Ok(model.Id);
        }

        [HttpGet("{theId}")]
        public IActionResult GetImage(Guid theId)
        {
            var image = _dbContext.Imagess.Where(ep => ep.TheId == theId).ToImmutableList();
            if (image == null)
                return NotFound();
            List<object> images = new List<object>();
             


            return Ok(image);
        }




        [HttpDelete("{theId}")]
        public IActionResult DeleteImage(Guid theId)
        {
            var image = _dbContext.Imagess.FirstOrDefault(i => i.TheId == theId);
            if (image == null)
                return NotFound();

            _dbContext.Imagess.Remove(image);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{theId}")]
        public IActionResult PutImage(Guid theId, [FromForm] Imagee model)
        {
            var image = _dbContext.Imagess.FirstOrDefault(i => i.TheId == theId);
            if (image == null)
                return NotFound();

            if (model.File != null && model.File.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    model.File.CopyTo(memoryStream);
                    image.ByteImage = memoryStream.ToArray();
                }
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
