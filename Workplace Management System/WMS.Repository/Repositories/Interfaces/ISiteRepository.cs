using WMS.Data.Entities.Core;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetSitesAsync(bool trackChanges);

        Task<Site> GetSiteAsync(Guid id, bool trackChanges);

        void CreateSite(Site site);

        Task<IEnumerable<Site>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        void DeleteSite(Site site);
    }
}
