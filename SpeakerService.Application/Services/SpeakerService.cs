using SpeakerService.Application.DTOs;
using SpeakerService.Application.Interfaces;
using SpeakerService.Domain.Data;
using SpeakerService.Domain.IRepositories;
using AutoMapper;
using SpeakerService.Domain.Entities;

namespace SpeakerService.Application.Services
{
    public class SpeakerServicee : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMapper _mapper;
      

        public SpeakerServicee(ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        public IEnumerable<GSpeakerDto> GetAllSpeakers()
        {
            var speakers = _speakerRepository.GetAllSpeakers();
            return _mapper.Map<IEnumerable<GSpeakerDto>>(speakers);
        }

        public GSpeakerDto GetSpeakerById(Guid id)
        {
            var speaker = _speakerRepository.GetSpeakerById(id);
            
            return _mapper.Map<GSpeakerDto>(speaker);
        }

        public void CreateSpeaker(CSpeakerDto speakerDto)
        {
            var speaker = _mapper.Map<Speaker>(speakerDto);
            _speakerRepository.CreateSpeaker(speaker);
        }

        public void UpdateSpeaker(GSpeakerDto speakerDto)
        {
            var speaker = _mapper.Map<Speaker>(speakerDto);
            _speakerRepository.UpdateSpeaker(speaker);
        }

        public void DeleteSpeaker(Guid id)
        {
            _speakerRepository.DeleteSpeaker(id);
        }

        

         
    }

}
