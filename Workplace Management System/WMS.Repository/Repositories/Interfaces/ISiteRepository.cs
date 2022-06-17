using WMS.Data.Entities.Core;

namespace WMS.Repository.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetAllSites(bool trackChanges);

        Site GetSite(Guid id, bool trackChanges);
    }
}
