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
    }
}
