using MediatR;
using ParamsService.Application.Interfaces;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.City.Commands;

public class CityCreateCmdHandler : IRequestHandler<CityCreateCmd, CityGetDto>
{
    private readonly IUnitOfService _service;
    public CityCreateCmdHandler(IUnitOfService service) => _service = service;




    public async Task<CityGetDto> Handle(CityCreateCmd request, CancellationToken cancellationToken)
    {
        var cityPostDTO = new CityCreateDto(request.Name);
        var city = await _service.CityService.CreateAsync(cityPostDTO);
        return city;
    }
}