using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Queries;

public class CityFindAllQueryHandler : IRequestHandler<CityFindAllQuery, IEnumerable<CityGetDto>>
{
    private readonly IUnitOfService _service;
    public CityFindAllQueryHandler(IUnitOfService service) => _service = service;




    public async Task<IEnumerable<CityGetDto>> Handle(CityFindAllQuery request, CancellationToken cancellationToken)
    {
        var cities = await _service.CityService.FindAllAsync();
        return cities;
    }
}