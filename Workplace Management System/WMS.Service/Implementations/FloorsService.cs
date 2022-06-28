using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using WMS.Data.Entities.Core;
using WMS.Data.RequestFeatures;
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

        public async Task<IEnumerable<FloorDto>> GetFloors(Guid siteId, bool trackChanges)
        {
            IEnumerable<Floor> floors = await _repository.Floor.GetFloorsAsync(siteId, trackChanges);

            IEnumerable<FloorDto> floorDtos = _mapper.Map<IEnumerable<FloorDto>>(floors);

            return floorDtos;
        }

        public async Task<PagedList<FloorDto>> GetFloors(Guid siteId, FloorParameters floorParameters, bool trackChanges)
        {
            PagedList<Floor> floors = await _repository.Floor.GetFloorsAsync(siteId, floorParameters, trackChanges);

            IEnumerable<FloorDto> floorDtos = _mapper.Map<IEnumerable<FloorDto>>(floors);

            PagedList<FloorDto> pagedFloorDtos = new PagedList<FloorDto>(
                floorDtos.ToList(),
                floors.MetaData.TotalCount,
                floors.MetaData.CurrentPage,
                floors.MetaData.PageSize);

            return pagedFloorDtos;
        }

        public async Task<FloorDto> GetFloor(Guid siteId, Guid id, bool trackChanges)
        {
            Floor floor = await _repository.Floor.GetFloorAsync(siteId, id, trackChanges);

            FloorDto floorDto = _mapper.Map<FloorDto>(floor);

            return floorDto;
        }

        public async Task<FloorDto> CreateFloor(Guid siteId, FloorForCreationDto floor)
        {
            var floorEntity = _mapper.Map<Floor>(floor);

            _repository.Floor.CreateFloor(siteId, floorEntity);

            await _repository.SaveAsync();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public async Task<FloorDto> UpdateFloorForSite(Guid siteId, Guid id, FloorForUpdateDto floor, bool trackChanges)
        {
            Floor floorEntity = await _repository.Floor.GetFloorAsync(siteId, id, trackChanges);

            _mapper.Map(floor, floorEntity);

            await _repository.SaveAsync();

            return _mapper.Map<FloorDto>(floorEntity);
        }

        public async Task DeleteFloor(Guid siteId, Guid id, bool trackChanges)
        {
            Floor floorForSite = await _repository.Floor.GetFloorAsync(siteId, id, trackChanges);

            _repository.Floor.DeleteFloor(floorForSite);

            await _repository.SaveAsync();
        }

        public async Task<FloorDto> PartiallyUpdateFloorForSite(Guid siteId, Guid id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges)
        {
            Floor floorEntity = await _repository.Floor.GetFloorAsync(siteId, id, trackChanges);

            FloorForUpdateDto floorToPatch = _mapper.Map<FloorForUpdateDto>(floorEntity);
            patchDoc.ApplyTo(floorToPatch);
            _mapper.Map(floorToPatch, floorEntity);

            await _repository.SaveAsync();

            return _mapper.Map<FloorDto>(floorEntity);
        }
    }
}
