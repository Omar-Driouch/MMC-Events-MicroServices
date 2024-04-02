using AutoMapper;

using MMC.Application.IRepositories;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;
using ParamsService.Domain.Entities;

namespace MMC.Application.Services;

public class SponsorService : ISponsorService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _map;
    public SponsorService(IUnitOfWork uow, IMapper map)
    {
        _uow = uow;
        _map = map;
    }

    public async Task<SponsorGetDto> FindAsync(Guid id)
    {
        var sponsor = await _uow.SponsorRepository.GetAsync(id);

        if (sponsor is null) return null;

        return _map.Map<SponsorGetDto>(sponsor);
    }
    public async Task<IEnumerable<SponsorGetDto>> FindAllAsync()
    {
        var sponsors = await _uow.SponsorRepository.GetAllAsync();

        if (sponsors is null) return null;

        return _map.Map<IEnumerable<SponsorGetDto>>(sponsors);
    }
    public async Task<SponsorGetDto> CreateAsync(SponsorCreateDto sponsorPostDTO)
    {
        var sponsor = _map.Map<Sponsor>(sponsorPostDTO);
        if (!await _uow.SponsorRepository.PostAsync(sponsor))
            return null;

        await _uow.CompleteAsync();
        return _map.Map<SponsorGetDto>(sponsor);
    }
    public async Task<SponsorGetDto> UpdateAsync(SponsorUpdateDto sponsorPutDTO)
    {
        var sponsor = _map.Map<Sponsor>(sponsorPutDTO);
        var updatedSponsor = await _uow.SponsorRepository.PutAsync(sponsor.Id, sponsor);

        await _uow.CompleteAsync();
        return _map.Map<SponsorGetDto>(updatedSponsor);
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _uow.SponsorRepository.RemoveAsync(id);
        await _uow.CompleteAsync();
        return success;
    }
}