using WMS.Data.Entities.Core;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface IFloorRepository
    {
        IEnumerable<Floor> GetFloors(Guid siteId, bool trackChanges);

        Floor GetFloor(Guid siteId, Guid id, bool trackChanges);
    }
}
