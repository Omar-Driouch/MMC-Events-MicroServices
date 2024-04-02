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
    public interface IPartnerEventRepository:IRepository<PartnerEvent>
    {
        Task<IEnumerable<PartnerEvent>> GetAllEventPartnersByEvent(Guid id);
    }
}
