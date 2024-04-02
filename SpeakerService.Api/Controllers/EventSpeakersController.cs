using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpeakerService.API.Services;
using SpeakerService.Application.DTOs;
using SpeakerService.Application.Interfaces;
using SpeakerService.Application.Services;
using SpeakerService.Domain.IRepositories;
using System.Text.Json;

namespace SpeakerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSpeakersController : ControllerBase
    {
        private readonly IEventSpeakerServices _eventSpeakerServices;
        private readonly ISpeakerRequestBroker _speakerRequestBroker;
        
        public EventSpeakersController( ISpeakerRequestBroker speakerRequestBroker, IEventSpeakerServices eventSpeakerServices)
        {
            
            _speakerRequestBroker = speakerRequestBroker;
            _eventSpeakerServices = eventSpeakerServices;
        }

 

        [HttpPost]
        [Authorize]
        
        public async Task<ActionResult<EventSpeakersDto>> CreateSpeaker(EventSpeakersDto speakerDto)
        {
            var result =  _eventSpeakerServices.CreateEventSpeaker(speakerDto);
            if (result) { return speakerDto; }
            else { return BadRequest("Error"); }
        }

        [HttpDelete("{SpekaerID}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteSpekaerFromEvent(Guid SpekaerID)
        {
            var result =  _eventSpeakerServices.DeleteSpeakerFromEvent(SpekaerID);
            if (result) { return Ok(result); }
            else { return BadRequest("Error");}
        }

        
        [HttpGet("AllEventsBySpeaker/{SpeakerID}")]
        public ActionResult<JToken> GetAllEventManagedBySpeaker(Guid SpeakerID)
        {
            try
            {
                var result = _eventSpeakerServices.GetAllEvenetsManagedBySpeaker(SpeakerID);
                List<EventOnlyGetDTO> listEvents = new List<EventOnlyGetDTO>();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        var Events = _speakerRequestBroker.RequestInfoFromEvents("Event", item.EventId.ToString());
                        if (Events != "null")
                        {
                            EventOnlyGetDTO member = System.Text.Json.JsonSerializer.Deserialize<EventOnlyGetDTO>(Events);
                            listEvents.Add(member);
                        }
                    }
                    return Ok(listEvents);
                }

                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error Message : " + ex.Message);
            }
        }

        [HttpGet("AllSpeakersByEvent/{EventID}")]
        public IActionResult GetAllSpeakersOfAnEvenet(Guid EventID)
        {
            try
            {
                var result = _eventSpeakerServices.GetAllSpeakersOfAnEvenet(EventID);

                if (result != null)
                {
                    
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error Message : " + ex.Message);
            }
        }


    }
}
