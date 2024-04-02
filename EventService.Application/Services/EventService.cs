using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Application.IRepositories;
using EventService.Domain.DTOs;
using EventService.Domain.Entities;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        public EventService(IUnitOfWork uow, IMapper map)
        {
            _uow = uow;
            _map = map;
        }




        public async Task<EventGetDTO> FindAsync(Guid id)
        {
            var @event = await _uow.EventRepository.GetAsync(id,e=>e.Program,e=>e.Sessions);

            if (@event is null) return null;

            return _map.Map<EventGetDTO>(@event);
        }

        public async Task<EventOnlyGetDTO> FindEventOnlyByIdAsync(Guid id)
        {
            var @event = await _uow.EventRepository.FindEventOnlyByIdAsync(id);

            if (@event is null) return null;

            return _map.Map<EventOnlyGetDTO>(@event);
        }

        public async Task<IEnumerable<EventGetDTO>> FindAllByProgramIdAsync(Guid Id)
        {
            var events = await _uow.EventRepository.GetEventsByProgramId(Id);

            if (events is null) return null;

            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
        public async Task<IEnumerable<EventGetDTO>> FindAllAsync()
        {
            var events = await _uow.EventRepository.GetAllAsync(e => e.Program, e => e.Sessions);

            if (events is null) return null;

            return _map.Map<IEnumerable<EventGetDTO>>(events);
        }
        public async Task<EventGetDTO> CreateAsync(EventPostDTO eventPostDTO)
        {
            var @event = _map.Map<Event>(eventPostDTO);
            if (!await _uow.EventRepository.PostAsync(@event))
                return null;

            await _uow.CompleteAsync();
            var createdEvent = await FindAsync(@event.Id);
            return createdEvent;
        }
        public async Task<EventGetDTO> UpdateAsync(EventPutDTO eventPutDTO)
        {
            var @event = _map.Map<Event>(eventPutDTO);
            var updatedEvent = await _uow.EventRepository.PutAsync(@event.Id, @event);

            await _uow.CompleteAsync();
            return _map.Map<EventGetDTO>(updatedEvent);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var success = await _uow.EventRepository.RemoveAsync(id);
            await _uow.CompleteAsync();
            return success;
        }

        public async Task<IEnumerable<EventOnlyGetDTO>> FindAllEventOnlyAsync()
        {
            var events = await _uow.EventRepository.GetAllAsync();

            if (events is null) return null;

            return _map.Map<IEnumerable<EventOnlyGetDTO>>(events);
        }
    }
}
