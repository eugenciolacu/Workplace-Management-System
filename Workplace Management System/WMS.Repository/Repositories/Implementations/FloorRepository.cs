using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using WMS.Data.Entities.Core;
using WMS.Data.RequestFeatures;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;
using WMS.Repository.Extensions;

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

        public async Task<PagedList<Floor>> GetFloorsAsync(Guid siteId, FloorParameters floorParameters, bool trackChanges)
        {
            var floors = await FindByCondition(f => f.SiteId.Equals(siteId), trackChanges)
                .FilterFloors(floorParameters.MinCapacity, floorParameters.MaxCapacity)
                .Search(floorParameters.SearchTerm)
                .Sort(floorParameters.OrderBy)
                .ToListAsync();

            return PagedList<Floor>
                .ToPagedList(floors, floorParameters.PageNumber, floorParameters.PageSize);

            //return await FindByCondition(f => f.SiteId.Equals(siteId), trackChanges)
            //    .OrderBy(f => f.Name)
            //    .Skip((floorParameters.PageNumber - 1) * floorParameters.PageSize)
            //    .Take(floorParameters.PageSize)
            //    .ToListAsync();
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
