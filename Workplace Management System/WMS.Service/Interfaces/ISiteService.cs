using WMS.Service.Dtos.Site;

namespace WMS.Service.Interfaces
{
    public interface ISiteService
    {
        IEnumerable<SiteDto> GetAllSites(bool trackChanges);
    }
}
