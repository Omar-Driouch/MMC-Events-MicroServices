using MediatR;
using ParamsService.Domain.DTOs;

namespace ParamsService.Application.Features.Mode.Queries
{
    public record ModeFindQuery(Guid Id):IRequest<ModeGetDto>;
}