using Microsoft.AspNetCore.JsonPatch;
using WMS.Data.RequestFeatures;
using WMS.Service.Dtos.Floor;

namespace WMS.Service.Interfaces
{
    public interface IFloorsService
    {
        Task DeleteFloor(Guid siteId, Guid id, bool trackChanges);
        Task<IEnumerable<FloorDto>> GetFloors(Guid siteId, bool trackChanges);
        Task<PagedList<FloorDto>> GetFloors(Guid siteId, FloorParameters floorParameters, bool trackChanges);
        Task<FloorDto> GetFloor(Guid siteId, Guid id, bool trackChanges);
        Task<FloorDto> CreateFloor(Guid siteId, FloorForCreationDto floor);
        Task<FloorDto> UpdateFloorForSite(Guid siteId, Guid id, FloorForUpdateDto floor, bool trackChanges);
        Task<FloorDto> PartiallyUpdateFloorForSite(Guid siteId, Guid id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges);
    }
}
