using SpeakerService.Application.DTOs;
using SpeakerService.Domain.Data;
using AutoMapper;
using SpeakerService.Domain.Entities;

namespace SpeakerService.Application.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Speaker, CSpeakerDto>().ReverseMap();
            CreateMap<Speaker, GSpeakerDto>().ReverseMap();
            CreateMap<EventSpeakers, EventSpeakersDto>();
            CreateMap<EventDto, EventSpeakers>().ReverseMap();
            CreateMap<SpeakerSocialMedia, CSpeakerSocialMediaDto>().ReverseMap();
            CreateMap<SpeakerSocialMedia, GSpeakerSocialMediaDto>().ReverseMap();
            CreateMap<EventSpeakersDto, EventSpeakers>()
                    .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId ))
                    .ForMember(dest => dest.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId  ));
            
        }
    }
}
