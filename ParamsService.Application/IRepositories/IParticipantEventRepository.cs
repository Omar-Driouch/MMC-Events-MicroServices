using MMC.Application.IRepositories;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.IRepositories
{
    public interface IParticipantEventRepository:IRepository<ParticipantEvent>
    {
        Task<IEnumerable<Participant>> GetAllEventPartticipantByEvent(Guid id);
        Task<bool> DeleteEventParticipantByEvent(Guid id);
        Task<bool> CheckIfUserIsAlreadyParticipated(Guid ParrticipantId, Guid EventID);
        Task<bool> UpdatedEventParticipantByEventQRCodeVerify(EventParticipantUpdateDto eventParticipantUpdateDto);
    }
}
