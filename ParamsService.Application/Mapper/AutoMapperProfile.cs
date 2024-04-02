using AutoMapper;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParamsService.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        //Partner Mapping
       
        public AutoMapperProfile()
        {
            CreateMap<City, CityGetDto>();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityUpdateDto, City>();
            
            
            CreateMap<Participant, ParticipantGetDto>();
            CreateMap<ParticipantCreateDto, Participant>();
            CreateMap<ParticipantUpdateDto, Participant>();
            
            CreateMap<Partner, PartnerGetDto>();
            CreateMap<PartnerCreateDto, Partner>();
            CreateMap<PartnerUpdateDto, Partner>();
            
            CreateMap<Sponsor, SponsorGetDto>();
            CreateMap<SponsorCreateDto, Sponsor>();
            CreateMap<SponsorUpdateDto, Sponsor>();
            
            CreateMap<Theme, ThemeGetDto>();
            CreateMap<ThemeCreateDto, Theme>();
            CreateMap<ThemeUpdateDto, Theme>();

             CreateMap<Mode, ModeGetDto>();
            CreateMap<ModeCreateDto, Mode>();
            CreateMap<ModeUpdateDto, Mode>();

            CreateMap<PartnerEvent, EventPartnerGetDto>();
            CreateMap<EventPartnerCreateDto, PartnerEvent>();
            CreateMap<EventPartnerUpdateDto, PartnerEvent>();
            CreateMap<PartnerEvent, EventPartnerCreateDto>();



           

            CreateMap<ParticipantEvent, EventParticipantGetDto>();
            CreateMap<EventParticipantGetDto, ParticipantEvent>();
            CreateMap<EventParticipantCreateDto, ParticipantEvent>();
           
            CreateMap<ParticipantEvent, EventParticipantCreateDto>();



        }



    }
}
