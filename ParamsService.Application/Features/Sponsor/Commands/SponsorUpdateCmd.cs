using MediatR;
using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Features.Sponsor.Commands
{
   public record SponsorUpdateCmd(
    Guid Id,
    string? Name,
    string? Description,
    string? Logo
       ) :IRequest<SponsorGetDto>;
}
