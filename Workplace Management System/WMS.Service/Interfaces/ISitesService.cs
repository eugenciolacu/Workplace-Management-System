using WMS.Service.Dtos.Site;

namespace WMS.Service.Interfaces
{
    public interface ISitesService
    {
        IEnumerable<SiteDto> GetAllSites(bool trackChanges);

        SiteDto GetSite(Guid id, bool trackChanges);
    }
}
