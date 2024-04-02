using AutoMapper;

using MMC.Application.IRepositories;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;

namespace MMC.Application.Services;

public class ModeService : IModeService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public ModeService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }


    public async Task<ModeGetDto> FindAsync(Guid id)
    {
        var mode = await _uow.ModeRepository.GetAsync(id);

        if (mode is null) return null;

        return _map.Map<ModeGetDto>(mode);
    }
    public async Task<IEnumerable<ModeGetDto>> FindAllAsync()
    {
        var modes = await _uow.ModeRepository.GetAllAsync();

        if (modes is null) return null;

        return _map.Map<IEnumerable<ModeGetDto>>(modes);
    }
    public async Task<ModeGetDto> CreateAsync(ModeCreateDto modePostDTO)
    {
        var mode = _map.Map<Mode>(modePostDTO);
        if (!await _uow.ModeRepository.PostAsync(mode))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<ModeGetDto>(mode);
    }
    public async Task<ModeGetDto> UpdateAsync(ModeUpdateDto modePutDTO)
    {
        var mode = _map.Map<Mode>(modePutDTO);
        var updatedMode = await _uow.ModeRepository.PutAsync(mode.Id, mode);

        await _uow.CompleteAsync();
        return _map.Map<ModeGetDto>(updatedMode);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.ModeRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}