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
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        public ProgramService(IUnitOfWork uow, IMapper map)
        {
            _uow = uow;
            _map = map;
        }




        public async Task<ProgramGetDTO> FindAsync(Guid id)
        {
            var @program= await _uow.ProgramRepository.GetAsync(id,p=>p.Events);

            if (@program is null) return null;

            return _map.Map<ProgramGetDTO>(@program);
        }

        public async Task<ProgramOnlyGetDTO> FindProgramOnlyAsync(Guid id)
        {
            var @program = await _uow.ProgramRepository.GetAsync(id);

            if (@program is null) return null;

            return _map.Map<ProgramOnlyGetDTO>(@program);
        }
        public async Task<IEnumerable<ProgramGetDTO>> FindAllAsync()
        {
            var programs = await _uow.ProgramRepository.GetAllAsync(p => p.Events);

            if (programs is null) return null;

            return _map.Map<IEnumerable<ProgramGetDTO>>(programs);
        }

        public async  Task<IEnumerable<ProgramOnlyGetDTO>> FindAllProgramOnly()
        {
            var programs = await _uow.ProgramRepository.GetAllAsync();

            if (programs is null) return null;

            return _map.Map<IEnumerable<ProgramOnlyGetDTO>>(programs);
        }


        public async Task<ProgramGetDTO> CreateAsync(ProgramPostDTO programPostDTO)
        {
            var @program = _map.Map<Program>(programPostDTO);
            if (!await _uow.ProgramRepository.PostAsync(@program))
                return null;

            await _uow.CompleteAsync();
            var createdProgram = await FindAsync(@program.Id);
            return createdProgram;
        }
        public async Task<ProgramGetDTO> UpdateAsync(ProgramPutDTO programPutDTO)
        {
            var @program = _map.Map<Program>(programPutDTO);
            var updatedProgram = await _uow.ProgramRepository.PutAsync(@program.Id, @program);

            await _uow.CompleteAsync();
            return _map.Map<ProgramGetDTO>(updatedProgram);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var success = await _uow.ProgramRepository.RemoveAsync(id);
            await _uow.CompleteAsync();
            return success;
        }
    }
}
