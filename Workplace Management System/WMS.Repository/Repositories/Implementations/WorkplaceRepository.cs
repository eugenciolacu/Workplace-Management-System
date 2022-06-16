using WMS.Data.Entities.Core;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class WorkplaceRepository : RepositoryBase<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(CoreDbContext coreDbContext) : base(coreDbContext)
        {

        }
    }
}
