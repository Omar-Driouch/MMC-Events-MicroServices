using ParamsService.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application.Interfaces
{
    public interface IPartnerEventService
    {
        Task<CityGetDto> FindAsync(Guid id);
        Task<IEnumerable<CityGetDto>> FindAllAsync();
        Task<CityGetDto> CreateAsync(CityCreateDto cityPostDTO);
        Task<CityGetDto> UpdateAsync(CityUpdateDto cityPutDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
