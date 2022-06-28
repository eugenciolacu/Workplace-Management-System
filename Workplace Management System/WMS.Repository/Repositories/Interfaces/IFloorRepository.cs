using WMS.Data.Entities.Core;
using WMS.Data.RequestFeatures;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface IFloorRepository
    {
        Task<Floor> GetFloorAsync(Guid siteId, Guid id, bool trackChanges);
        Task<IEnumerable<Floor>> GetFloorsAsync(Guid siteId, bool trackChanges); // modified this
        Task<PagedList<Floor>> GetFloorsAsync(Guid siteId, FloorParameters floorParameters, bool trackChanges);
        void CreateFloor(Guid siteId, Floor floor);
        void DeleteFloor(Floor floor);
    }
}
