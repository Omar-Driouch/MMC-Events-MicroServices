using MediatR;
using ParamsService.Application.Interfaces;


namespace MMC.Application.Features.City.Commands;

public class CityDeleteCmdHandler : IRequestHandler<CityDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public CityDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(CityDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.CityService.DeleteAsync(request.Id);
        return success;
    }
}