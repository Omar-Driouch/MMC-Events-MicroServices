using IronBarCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMC.Application.Features.EventParticipant.Commands;
using MMC.Application.Features.EventParticipant.Queries;
using MMC.Application.Features.EventPartner.Commands;
using Newtonsoft.Json;
using ParamsService.API.Services;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParamsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipantController : ControllerBase
    {
        private readonly INotificationsServer? _notify;
        private readonly IMediator _mediator;
        private readonly IRabbitMQ _rabbitMQ;

       

        public EventParticipantController(INotificationsServer notify, IMediator mediator, IRabbitMQ rabbitMQ)
        {
            _notify = notify;
            _mediator = mediator;
            _rabbitMQ = rabbitMQ;
          

        }
        // POST: api/EventPartner
        [HttpPost]
        public async Task<IActionResult> CreateNewParticipantEvent(EventParticipantCreateCmd cmd)
        {
            try
            {
                var Event = await _rabbitMQ.RequestMethod("Event", cmd.id_Event.ToString());
                var particpinat = await _notify.RequestDatafromParticipants("Participant", cmd.id_Participant.ToString());
                var EventjsonData = JsonConvert.DeserializeObject<dynamic>((string)Event);
                var particpinatjsonData = JsonConvert.DeserializeObject<dynamic>((string)particpinat);
                try
                {
                    var id = EventjsonData.Id;
                    var pId = particpinatjsonData.Id;
                    if (id != cmd.id_Event) { return BadRequest("Event ID does not exist !"); }
                }
                catch (Exception err)
                {
                    return NotFound("Event ID or Participant ID does not exist !");
                }
                var partner = await _mediator.Send(cmd);
                if (partner != null) { var tt = _notify.SendNotificationVia("Email", cmd.id_Participant.ToString(), cmd.id_Event.ToString()); }
                return partner is null ? NotFound() : Ok(partner);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
             
        }

        [HttpGet(template: $"{{Id}}")]
        public async Task<IActionResult> FindParticipantByEvent(Guid Id)
        {
            var partner = await _mediator.Send(new EventParticipantFindQuery(Id));
            return partner is null ? NotFound() : Ok(partner);
        }


        [HttpDelete(template: $"{{Id}}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var success = await _mediator.Send(new EventParticipantDeleteCmd(Id));
            return success ? Ok(success) : NotFound();
        }


        [HttpPut("VerifyQRCode")]
        public async Task<IActionResult> VerifyQrCode(EventParticipantUpdateDto cmd)
        {
            var success = await _mediator.Send(new EventParticipantUpdateCmd(cmd));
            if (success != null) { return Ok(success); }
            return NotFound();
        }
    }
}
