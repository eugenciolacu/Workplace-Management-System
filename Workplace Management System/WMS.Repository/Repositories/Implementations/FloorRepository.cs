using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Floor>> GetFloorsAsync(Guid siteId, bool trackChanges)
        {
            return await FindByCondition(f => f.SiteId.Equals(siteId), trackChanges)
                .OrderBy(f => f.Name).ToListAsync();
        }

        public async Task<Floor> GetFloorAsync(Guid siteId, Guid id, bool trackChanges)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await FindByCondition(f => f.SiteId.Equals(siteId) && f.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
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
