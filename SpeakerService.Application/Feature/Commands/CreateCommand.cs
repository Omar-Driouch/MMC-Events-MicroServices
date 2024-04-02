using MediatR;
using SpeakerService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Application.Feature.Commands
{
    public class CreateCommand(
        string FirstName, 
        string LastName, 
        string Bio, 
        string Comapny ,
        string Email,
        string PicturePath ,
        bool MVP,
        bool MCT,
        string Description ,
        CSpeakerSocialMediaDto SpeakerSocialMedia
        ) : IRequest<CSpeakerDto>;
}
