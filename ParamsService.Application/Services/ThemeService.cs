using AutoMapper;

using MMC.Application.IRepositories;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;

namespace MMC.Application.Services;

public class ThemeService : IThemeService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public ThemeService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<ThemeGetDto> FindAsync(Guid id)
    {
        var theme = await _uow.ThemeRepository.GetAsync(id);

        if (theme is null) return null;

        return _map.Map<ThemeGetDto>(theme);
    }
    public async Task<IEnumerable<ThemeGetDto>> FindAllAsync()
    {
        var themes = await _uow.ThemeRepository.GetAllAsync();

        if (themes is null) return null;

        return _map.Map<IEnumerable<ThemeGetDto>>(themes);
    }
    public async Task<ThemeGetDto> CreateAsync(ThemeCreateDto themePostDTO)
    {
        var theme = _map.Map<Theme>(themePostDTO);
        if (!await _uow.ThemeRepository.PostAsync(theme))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<ThemeGetDto>(theme);
    }
    public async Task<ThemeGetDto> UpdateAsync(ThemeUpdateDto themePutDTO)
    {
        var theme = _map.Map<Theme>(themePutDTO);
        var updatedTheme = await _uow.ThemeRepository.PutAsync(theme.Id, theme);

        await _uow.CompleteAsync();
        return _map.Map<ThemeGetDto>(updatedTheme);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.ThemeRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}