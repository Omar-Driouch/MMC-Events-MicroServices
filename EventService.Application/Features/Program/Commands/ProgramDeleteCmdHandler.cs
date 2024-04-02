using MediatR;
using EventService.Application.Interfaces;

namespace EventService.Application.Features.Program.Commands;
    
public class ProgramDeleteCmdHandler : IRequestHandler<ProgramDeleteCmd, bool>
{
    private readonly IUnitOfService _service;
    public ProgramDeleteCmdHandler(IUnitOfService service) => _service = service;




    public async Task<bool> Handle(ProgramDeleteCmd request, CancellationToken cancellationToken)
    {
        bool success = await _service.ProgramService.DeleteAsync(request.Id);
        return success;
    }
}