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
    public class PartnerEventRepository : Repository<PartnerEvent> , IPartnerEventRepository
    {
        private readonly MMC_Params _db;
       

        public PartnerEventRepository(MMC_Params db) : base(db)
        {
            _db = db;
        }

        

        public async Task<IEnumerable<PartnerEvent>> GetAllEventPartnersByEvent(Guid id)
        {
            var eventPartners = await _db.PartnerEvent
                                         
                                         .Where(ep => ep.EventId == id)
                                         .ToListAsync();
            return (eventPartners);

        }


    }
}
