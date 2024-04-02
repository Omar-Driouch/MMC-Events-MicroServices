using AutoMapper;

using MMC.Application.IRepositories;

using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Services;

public class EventPartnerService : IEventPartnerService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public EventPartnerService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<IEnumerable<PartnerGetDto>> GetAllEventPartnersByEvent(Guid id)
    {
        var partners = await _uow.EventPartnerRepository.GetAllEventPartnersByEvent(id);
        List<PartnerGetDto> result = new List<PartnerGetDto>();
        foreach (var partner in partners)
        {
            var part = await _uow.PartnerRepository.GetAsync(partner.PartnerId);
            var partnerre = _map.Map<PartnerGetDto>(part);
            if (partnerre != null) { result.Add(partnerre); }
        }
        if (result == null || !result.Any())
            return Enumerable.Empty<PartnerGetDto>();

        var partnerDtos = _map.Map<IEnumerable<PartnerGetDto>>(result);

        return partnerDtos;
    }

    public async Task<IEnumerable<EventPartnerGetDto>> FindAllAsync()
    {
        var partners = await _uow.EventPartnerRepository.GetAllAsync();

        if (partners is null) return null;

        return _map.Map<IEnumerable<EventPartnerGetDto>>(partners);
    }
    public async Task<EventPartnerCreateDto> CreateAsync(EventPartnerCreateDto partnerPostDTO)
    {
        var partner = _map.Map<PartnerEvent>(partnerPostDTO);
        if (!await _uow.EventPartnerRepository.PostAsync(partner))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<EventPartnerCreateDto>(partner);
    }
    public async Task<EventPartnerGetDto> UpdateAsync(PartnerUpdateDto partnerPutDTO)
    {
        var partner = _map.Map<PartnerEvent>(partnerPutDTO);
        var updatedPartner = await _uow.EventPartnerRepository.PutAsync(partner.Id, partner);

        await _uow.CompleteAsync();
        return _map.Map<EventPartnerGetDto>(updatedPartner);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.EventPartnerRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}