using AutoMapper;
using MMC.Application.IRepositories;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;

namespace MMC.Application.Services;

public class CityService : ICityService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public CityService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }


    public async Task<CityGetDto> FindAsync(Guid id)
    {
        var city = await _uow.CityRepository.GetAsync(id,c=>c.Participants);

        if (city is null) return null;

        return _map.Map<CityGetDto>(city);
    }
    public async Task<IEnumerable<CityGetDto>> FindAllAsync()
    {
        var cities = await _uow.CityRepository.GetAllAsync(c =>c.Participants);

        if (cities is null) return null;

        return _map.Map<IEnumerable<CityGetDto>>(cities);
    }
    public async Task<CityGetDto> CreateAsync(CityCreateDto cityPostDTO)
    {
        var city = _map.Map<City>(cityPostDTO);
        if (!await _uow.CityRepository.PostAsync(city))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<CityGetDto>(city);
    }
    public async Task<CityGetDto> UpdateAsync(CityUpdateDto cityPutDTO)
    {
        var city = _map.Map<City>(cityPutDTO);
        var updatedCity = await _uow.CityRepository.PutAsync(city.Id, city);

        await _uow.CompleteAsync();
        return _map.Map<CityGetDto>(updatedCity);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.CityRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}