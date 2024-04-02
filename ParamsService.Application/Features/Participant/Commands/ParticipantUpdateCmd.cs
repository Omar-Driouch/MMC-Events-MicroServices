using MediatR;
using ParamsService.Domain.DTOs;


namespace MMC.Application.Features.Participant.Commands;

public record ParticipantUpdateCmd(Guid Id ,string? FirstName,
     string? LastName,
     string? Email,
     string? Phone,
     string? Gender,
     string City) : IRequest<ParticipantGetDto>;