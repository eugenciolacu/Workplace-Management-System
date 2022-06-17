using WMS.Data.Entities.Core;
using WMS.Repository.Contexts;
using WMS.Repository.Repositories.Interfaces;

namespace WMS.Repository.Repositories.Implementations
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepository(CoreDbContext coreDbContext) : base(coreDbContext)
        {

        }

        public IEnumerable<Site> GetAllSites(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(s => s.Name)
                .ToList();
        }

        public Site GetSite(Guid id, bool trackChanges)
        {
            return FindByCondition(s => s.Id.Equals(id), trackChanges)
                .SingleOrDefault()!;
        }
    }
}