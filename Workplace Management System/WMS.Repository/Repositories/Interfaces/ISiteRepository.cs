using WMS.Data.Entities.Core;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetSites(bool trackChanges);

        IEnumerable<Site> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        Site GetSite(Guid id, bool trackChanges);

        void CreateSite(Site site);

        void DeleteSite(Site site);
    }
}
