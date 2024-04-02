using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;

namespace MMC.Application.Features.City.Commands;

public class CityUpdateCmdHandler : IRequestHandler<CityUpdateCmd, CityGetDto>
{
    private readonly IUnitOfService _service;
    public CityUpdateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<CityGetDto> Handle(CityUpdateCmd request, CancellationToken cancellationToken)
    {
        var cityPutDTO = new CityUpdateDto(request.Id, request.Name);
        var city = await _service.CityService.UpdateAsync(cityPutDTO);
        return city;
    }
}