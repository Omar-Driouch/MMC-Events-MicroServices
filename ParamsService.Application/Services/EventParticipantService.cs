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

public class EventParticipantService : IEventParticipantService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public EventParticipantService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<IEnumerable<ParticipantGetDto>> GetAllEventParticipantByEvent(Guid id)
    {
        var partners = await _uow.ParticipantEventRepository.GetAllEventPartticipantByEvent(id);

        if (partners == null || !partners.Any())
            return Enumerable.Empty<ParticipantGetDto>();

        try
        {
            var partnerDtos = _map.Map<IEnumerable<ParticipantGetDto>>(partners);
            return partnerDtos;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        
    }

    public async Task<IEnumerable<EventPartnerGetDto>> FindAllAsync()
    {
        var partners = await _uow.EventPartnerRepository.GetAllAsync();

        if (partners is null) return null;

        return _map.Map<IEnumerable<EventPartnerGetDto>>(partners);
    }
    public async Task<EventParticipantCreateDto> CreateAsync(EventParticipantCreateDto partnerPostDTO)
    {
        var partner = _map.Map<ParticipantEvent>(partnerPostDTO);
        var isAlreadyPraticipted = await _uow.ParticipantEventRepository.CheckIfUserIsAlreadyParticipated(partnerPostDTO.id_Participant, partnerPostDTO.Id_Event);
        if (!isAlreadyPraticipted)
        {
            if (!await _uow.ParticipantEventRepository.PostAsync(partner))
                return null;
            await _uow.CompleteAsync();
            return _map.Map<EventParticipantCreateDto>(partner);
        }

        return null;


    }
     
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.ParticipantEventRepository.DeleteEventParticipantByEvent(id);
        await _uow.CompleteAsync();
        return success;
    }

    public Task<IEnumerable<EventParticipantGetDto>> GetAllEventPartnersByEvent(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<EventParticipantGetDto>> IEventParticipantService.FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(EventParticipantUpdateDto EventParticipantPostDTO)
    {
        var success = await _uow.ParticipantEventRepository.UpdatedEventParticipantByEventQRCodeVerify(EventParticipantPostDTO);
        
        return success;
    }
}