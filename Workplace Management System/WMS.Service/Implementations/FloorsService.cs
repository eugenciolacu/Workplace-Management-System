using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        public FloorDto CreateFloor(Guid siteId, FloorForCreationDto floor)
        {
            var floorEntity = _mapper.Map<Floor>(floor);

            _repository.Floor.CreateFloor(siteId, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public FloorDto UpdateFloorForSite(Guid siteId, Guid id, FloorForUpdateDto floor, bool trackChanges)
        {
            Floor floorEntity = _repository.Floor.GetFloor(siteId, id, trackChanges);

            _mapper.Map(floor, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public void DeleteFloor(Guid siteId, Guid id, bool trackChanges)
        {
            Floor floorForSite = _repository.Floor.GetFloor(siteId, id, trackChanges);

            _repository.Floor.DeleteFloor(floorForSite);

            _repository.Save();
        }

        public FloorDto PartiallyUpdateFloorForSite(Guid siteId, Guid id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges)
        {
            Floor floorEntity = _repository.Floor.GetFloor(siteId, id, trackChanges);

            FloorForUpdateDto floorToPatch = _mapper.Map<FloorForUpdateDto>(floorEntity);
            patchDoc.ApplyTo(floorToPatch);
            _mapper.Map(floorToPatch, floorEntity);

            _repository.Save();

            return _mapper.Map<FloorDto>(floorEntity);
        }
    }
}
