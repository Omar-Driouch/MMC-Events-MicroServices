using MediatR;
using SpeakerService.Application.DTOs;
using SpeakerService.Application.Interfaces;
using SpeakerService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.Feature.Commands
{
    public class CreateCommandHandler
    {
        private readonly ISpeakerService _speakerService;
        public CreateCommandHandler(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }
    }
}
