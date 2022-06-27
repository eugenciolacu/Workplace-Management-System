using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Site>> GetSitesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Site> GetSiteAsync(Guid id, bool trackChanges)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await FindByCondition(s => s.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void CreateSite(Site site)
        {
            Create(site);
        }

        public async Task<IEnumerable<Site>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();
        }

        public void DeleteSite(Site site)
        {
            Delete(site);
        }
    }
}