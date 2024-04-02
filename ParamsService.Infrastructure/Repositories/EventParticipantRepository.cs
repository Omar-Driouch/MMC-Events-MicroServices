using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MMC.Infrastructure.Repositories;
using ParamsService.Application.IRepositories;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;
using ParamsService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Infrastructure.Repositories
{
    public class EventParticipantRepository : Repository<ParticipantEvent> , IParticipantEventRepository
    {
        private readonly MMC_Params _db;
       

        public EventParticipantRepository(MMC_Params db) : base(db)
        {
            _db = db;
        }

        

        public async Task<IEnumerable<Participant>> GetAllEventPartticipantByEvent(Guid id)
        {
            var eventParticipants = await _db.ParticipantEvent
                                         .Where(ep => ep.Id_Event == id)
                                         .ToListAsync();
            List<Participant> result = new List<Participant>();
            foreach (var eventParticipant in eventParticipants)
            {
                var Participants = await _db.Participants.Where(p => p.Id == eventParticipant.Id_Participant).FirstOrDefaultAsync();
                result.Add(Participants);
            }
            return (result);

        }

        public async Task<bool> DeleteEventParticipantByEvent(Guid id)
        {
            try
            {
                var eventParticipants = await _db.ParticipantEvent
                                                  .Where(ep => ep.Id_Event == id)
                                                  .ToListAsync();

                _db.ParticipantEvent.RemoveRange(eventParticipants);
            var isSaved =     await _db.SaveChangesAsync();

                return isSaved > 0; 
            }
            catch (Exception ex)
            {
                
             
                return false; 
            }
        }

        public async Task<bool> UpdatedEventParticipantByEventQRCodeVerify(EventParticipantUpdateDto eventParticipantUpdateDto)
        {
            try
            {
                var eventParticipants = await _db.ParticipantEvent
                                                   .Where(ep => ep.Id_Event == eventParticipantUpdateDto.Id_Event &&
                                                    ep.Id_Participant == eventParticipantUpdateDto.id_Participant).ToListAsync();
                if (eventParticipants.Count > 0)
                {
                    foreach (var item in eventParticipants)
                    {
                        item.IsParticipated = true;
                    }
                }
                var isSaved = await _db.SaveChangesAsync();

                return isSaved > 0;
            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public async Task<bool> CheckIfUserIsAlreadyParticipated(Guid ParrticipantId, Guid EventID)
        {
            
                var eventParticipants = await _db.ParticipantEvent
                                                   .Where(ep => ep.Id_Participant == ParrticipantId && ep.Id_Event == EventID && ep.IsParticipated==false).FirstOrDefaultAsync();
                if (eventParticipants != null) { return true; }
                return false;
             
        }
    }
}
