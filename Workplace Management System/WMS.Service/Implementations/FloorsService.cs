﻿using AutoMapper;
using WMS.Data.Entities.Core;
using WMS.Repository.Repositories.Interfaces;
using WMS.Service.Dtos.Floor;
using WMS.Service.Interfaces;

namespace WMS.Service.Implementations
{
    public class FloorsService : IFloorsService
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public FloorsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<FloorDto> GetFloors(Guid siteId, bool trackChanges)
        {
            IEnumerable<Floor> floors = _repository.Floor.GetFloors(siteId, trackChanges);

            IEnumerable<FloorDto> floorDtos = _mapper.Map<IEnumerable<FloorDto>>(floors);

            return floorDtos;
        }

        public FloorDto GetFloor(Guid siteId, Guid id, bool trackChanges)
        {
            Floor floor = _repository.Floor.GetFloor(siteId, id, trackChanges);

            FloorDto floorDto = _mapper.Map<FloorDto>(floor);

            return floorDto;
        }
    }
}