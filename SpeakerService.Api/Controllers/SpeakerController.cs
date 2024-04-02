using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeakerService.Application.DTOs;
using SpeakerService.Application.Interfaces;
using SpeakerService.Application.Services;

namespace SpeakerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }


        [HttpGet]
        public IActionResult GetAllSpeakers()
        {
            var speakers = _speakerService.GetAllSpeakers();
            return Ok(speakers);
        }


        [HttpGet("{id}")]
        public IActionResult GetSpeakerById(Guid id)
        {
            var speaker = _speakerService.GetSpeakerById(id);
            if (speaker == null)
            {
                return NotFound();
            }
            return Ok(speaker);
        }

        [HttpPost]
        public IActionResult CreateSpeaker(CSpeakerDto speakerDto)
        {
            _speakerService.CreateSpeaker(speakerDto);
            return CreatedAtAction(nameof(GetSpeakerById), new { id = speakerDto.Id }, speakerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpeaker(Guid id, GSpeakerDto speakerDto)
        {
            _speakerService.UpdateSpeaker(speakerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpeaker(Guid id)
        {
            _speakerService.DeleteSpeaker(id);
            return NoContent();
        }
    }
}
