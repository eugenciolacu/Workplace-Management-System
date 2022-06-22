using Microsoft.AspNetCore.JsonPatch;
using WMS.Service.Dtos.Floor;

namespace WMS.Service.Interfaces
{
    public interface IFloorsService
    {
        void DeleteFloor(Guid siteId, Guid id, bool trackChanges);
        IEnumerable<FloorDto> GetFloors(Guid siteId, bool trackChanges);
        public FloorDto GetFloor(Guid siteId, Guid id, bool trackChanges);
        FloorDto CreateFloor(Guid siteId, FloorForCreationDto floor);
        FloorDto UpdateFloorForSite(Guid siteId, Guid id, FloorForUpdateDto floor, bool trackChanges);
        FloorDto PartiallyUpdateFloorForSite(Guid siteId, Guid id, JsonPatchDocument<FloorForUpdateDto> patchDoc, bool trackChanges);
    }
}
