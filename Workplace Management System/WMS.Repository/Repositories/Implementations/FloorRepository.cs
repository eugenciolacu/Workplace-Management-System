using WMS.Data.Entities.Core;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class FloorRepository : RepositoryBase<Floor>, IFloorRepository
    {
        public FloorRepository(CoreDbContext coreDbContext) : base(coreDbContext)
        {

        }

        public IEnumerable<Floor> GetFloors(Guid siteId, bool trackChanges)
        {
            return FindByCondition(f => f.SiteId.Equals(siteId), trackChanges)
                .OrderBy(f => f.Name);
        }

        public Floor GetFloor(Guid siteId, Guid id, bool trackChanges)
        {
            return FindByCondition(f => f.SiteId.Equals(siteId) && f.Id.Equals(id), trackChanges)
                .SingleOrDefault()!;
        }

        public void CreateFloor(Guid siteId, Floor floor)
        {
            floor.SiteId = siteId;
            Create(floor);
        }

        public void DeleteFloor(Floor floor)
        {
            Delete(floor);
        }
    }
}
