using MediatR;
using EventService. Application.Interfaces;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Program.Queries;

public class ProgramFindQueryHandler : IRequestHandler<ProgramFindQuery, ProgramGetDTO>
{
    private readonly IUnitOfService _service;
    public ProgramFindQueryHandler(IUnitOfService service) => _service = service;




    public async Task<ProgramGetDTO> Handle(ProgramFindQuery request, CancellationToken cancellationToken)
    {
        var program = await _service.ProgramService.FindAsync(request.Id);
        return program;
    }
}