using MediatR;
using EventService.Application.Interfaces;
using EventService.Domain.DTOs;

namespace EventService.Application.Features.Program.Queries
{
    public class ProgramOnlyFindQueryAllHandler : IRequestHandler<ProgramOnlyFindAllQuery, IEnumerable<ProgramOnlyGetDTO>>
    {
        private readonly IUnitOfService _service;
        public ProgramOnlyFindQueryAllHandler(IUnitOfService service) => _service = service;




        public async Task<IEnumerable<ProgramOnlyGetDTO>> Handle(ProgramOnlyFindAllQuery request, CancellationToken cancellationToken)
        {
            var program = await _service.ProgramService.FindAllProgramOnly();
            return program;
        }

      
    }
}
