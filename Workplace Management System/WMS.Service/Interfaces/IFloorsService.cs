using WMS.Service.Dtos.Floor;

namespace WMS.Service.Interfaces
{
    public interface IFloorsService
    {
        IEnumerable<FloorDto> GetFloors(Guid siteId, bool trackChanges);
        public FloorDto GetFloor(Guid siteId, Guid id, bool trackChanges);
    }
}
