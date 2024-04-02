using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Application.IRepositories;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Services
{

    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        public SessionService(IUnitOfWork uow, IMapper map)
        {
            _uow = uow;
            _map = map;
        }




        public async Task<SessionGetDTO> FindAsync(Guid id)
        {
            var session = await _uow.SessionRepository.GetAsync(id,s=>s.Event);

            if (session is null) return null;

            return _map.Map<SessionGetDTO>(session);
        }

        public async Task<SessionOnlyGetDTO> FindSessionOnlyByIdAsync(Guid id)
        {
            var session = await _uow.SessionRepository.GetAsync(id);

            if (session is null) return null;

            return _map.Map<SessionOnlyGetDTO>(session);
        }
        public async Task<IEnumerable<SessionGetDTO>> FindAllByEventIdAsync(Guid Id)
        {
            var sessions = await _uow.SessionRepository.GetSessionByEventId(Id);

            if (sessions is null) return null;

            return _map.Map<IEnumerable<SessionGetDTO>>(sessions);
        }
        public async Task<IEnumerable<SessionOnlyGetDTO>> FindAllSession()
        {
            var sessions = await _uow.SessionRepository.GetAllAsync();

            if (sessions is null) return null;

            return _map.Map<IEnumerable<SessionOnlyGetDTO>>(sessions);
        }
        public async Task<IEnumerable<SessionGetDTO>> FindAllAsync()
        {
            var sessions = await _uow.SessionRepository.GetAllAsync(s=>s.Event);

            if (sessions is null) return null;

            return _map.Map<IEnumerable<SessionGetDTO>>(sessions);
        }
        public async Task<SessionGetDTO> CreateAsync(SessionPostDTO sessionPostDTO)
        {
            var session = _map.Map<Session>(sessionPostDTO);
            if (!await _uow.SessionRepository.PostAsync(session))
                return null;

            await _uow.CompleteAsync();
            var createdSession = await FindAsync(session.Id);
            return createdSession;
        }
        public async Task<SessionGetDTO> UpdateAsync(SessionPutDTO sessionPutDTO)
        {
            var session = _map.Map<Session>(sessionPutDTO);
            var updatedSession = await _uow.SessionRepository.PutAsync(session.Id, session);

            await _uow.CompleteAsync();
            return _map.Map<SessionGetDTO>(updatedSession);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var success = await _uow.SessionRepository.RemoveAsync(id);
            await _uow.CompleteAsync();
            return success;
        }

        
    }
}