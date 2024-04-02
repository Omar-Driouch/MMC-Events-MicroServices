using SpeakerService.Application.DTOs;
using SpeakerService.Application.Interfaces;
using SpeakerService.Domain.Data;
using SpeakerService.Domain.IRepositories;
using AutoMapper;
using SpeakerService.Domain.Entities;

namespace SpeakerService.Application.Services
{
    public class EventSpeakerServices : IEventSpeakerServices
    {
        private readonly IEventSpeakersRepository _eventSpeakers;
        private readonly ISpeakerRepository _speakers;
        private readonly IMapper _mapper;

        public EventSpeakerServices(IEventSpeakersRepository eventSpeakers, ISpeakerRepository speakers, IMapper mapper)
        {
            _eventSpeakers = eventSpeakers;
            _mapper = mapper;
            _speakers = speakers;
        }

        public bool CreateEventSpeaker(EventSpeakersDto eventSpeakersDto)
        {
           var SE = _mapper.Map<EventSpeakers>(eventSpeakersDto);
          var isCreated =  _eventSpeakers.CreateEventSpeaker(SE);
            return isCreated;
                

        }

        public bool DeleteSpeakerFromEvent(Guid SpeakerID)
        {
            var isDeleted = _eventSpeakers.DeleteSpeakerFromEvent(SpeakerID);
            return isDeleted;
        }


        public bool DeleteEventFromSpeakerEvent(Guid EventID)
        {
            // call this function in the Broker if an Evenet deleted in the services 
            var isDeleted = _eventSpeakers.DeleteEventFromSpeakerEvent(EventID);
            return isDeleted;
        }

        public IEnumerable<GSpeakerDto> GetAllSpeakersOfAnEvenet(Guid EventID)
        {
            var speakers = _eventSpeakers.GetAllSpeakersOfAnEvent(EventID);
            List<GSpeakerDto> gSpeakerDtos = new List<GSpeakerDto>();

            foreach (var speaker in speakers)
            {
                var speakerDto = _speakers.GetSpeakerById(speaker.SpeakerId);
                gSpeakerDtos.Add(_mapper.Map<GSpeakerDto>(speakerDto));
            }

            return gSpeakerDtos;
        }

        public IEnumerable<EventDto> GetAllEvenetsManagedBySpeaker(Guid SpeakerID)
        {   
            var events = _eventSpeakers.GetAllEvenetsManagedBySpeaker(SpeakerID);
            
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        




    }

}
