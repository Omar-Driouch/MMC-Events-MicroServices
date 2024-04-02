using AutoMapper;
using EventService.Application.Interfaces;
using EventService.Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application.Services
{
    public class UnitOfService : IUnitOfService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;

        public IEventService EventService { get; private set; }
        public ISessionService SessionService { get; private set; }

        public IProgramService ProgramService { get; private set; }



        public UnitOfService(IUnitOfWork uow, IMapper map)
        {
            _uow = uow;
            _map = map;

            EventService = new EventService(_uow, _map);
            SessionService = new SessionService(_uow, _map);
            ProgramService = new ProgramService(_uow, _map);


        }
    }
}
