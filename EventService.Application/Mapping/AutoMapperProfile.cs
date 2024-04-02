using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using EventService.Domain.Entities;
using EventService.Domain.DTOs;
namespace EventService.Application.Mapping
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //Event Mapping
            CreateMap<Event, EventGetDTO>();
            CreateMap<Event, EventOnlyGetDTO>();
            CreateMap<EventPostDTO, Event>();
            CreateMap<EventPutDTO, Event>();


            //Session Mapping
            CreateMap<Session, SessionGetDTO>();
            CreateMap<Session, SessionOnlyGetDTO>();

            CreateMap<SessionPostDTO, Session>();
            CreateMap<SessionPutDTO, Session>();



            //Program Mapping
            CreateMap<Program, ProgramGetDTO>();
            CreateMap<Program, ProgramOnlyGetDTO>();
            CreateMap<ProgramPostDTO, Program>();
            CreateMap<ProgramPutDTO, Program>();

        }
    }
}
