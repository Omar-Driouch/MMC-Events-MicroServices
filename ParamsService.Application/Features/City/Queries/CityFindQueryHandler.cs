using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Queries;

public class CityFindQueryHandler : IRequestHandler<CityFindQuery, CityGetDto>
{
    private readonly IUnitOfService _service;
    public CityFindQueryHandler(IUnitOfService service) => _service = service;




    public async Task<CityGetDto> Handle(CityFindQuery request, CancellationToken cancellationToken)
    {
        var city = await _service.CityService.FindAsync(request.Id);
        return city;
    }
}