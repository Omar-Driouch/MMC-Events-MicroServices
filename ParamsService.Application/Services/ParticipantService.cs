using AutoMapper;

using MMC.Application.IRepositories;

using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;

namespace MMC.Application.Services;

public class ParticipantService : IParticipantService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public ParticipantService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }




    public async Task<ParticipantGetDto> FindAsync(Guid id)
    {
        var participant = await _uow.ParticipantRepository.GetAsync(id);

        if (participant is null) return null;

        return _map.Map<ParticipantGetDto>(participant);
    }
    public async Task<IEnumerable<ParticipantGetDto>> FindAllAsync()
    {
        var participants = await _uow.ParticipantRepository.GetAllAsync();

        if (participants is null) return null;

        return _map.Map<IEnumerable<ParticipantGetDto>>(participants);
    }
    public async Task<ParticipantGetDto> CreateAsync(ParticipantCreateDto participantPostDTO)
    {
        var participant = _map.Map<Participant>(participantPostDTO);
        if (!await _uow.ParticipantRepository.PostAsync(participant))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<ParticipantGetDto>(participant);
    }
    public async Task<ParticipantGetDto> UpdateAsync(ParticipantUpdateDto participantPutDTO)
    {
        var participant = _map.Map<Participant>(participantPutDTO);
        var updatedParticipant = await _uow.ParticipantRepository.PutAsync(participant.Id, participant);

        await _uow.CompleteAsync();
        return _map.Map<ParticipantGetDto>(updatedParticipant);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.ParticipantRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}