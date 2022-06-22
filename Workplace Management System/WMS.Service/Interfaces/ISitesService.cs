using WMS.Service.Dtos.Site;

namespace WMS.Service.Interfaces
{
    public interface ISitesService
    {
        void DeleteSite(Guid id, bool trackChanges);

        IEnumerable<SiteDto> GetSites(bool trackChanges);

        SiteDto GetSite(Guid id, bool trackChanges);

        SiteDto CreateSite(SiteForCreationDto site);

        IEnumerable<SiteDto> GetSiteCollection(IEnumerable<Guid> ids, bool trackChanges);

        IEnumerable<SiteDto> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection);

        SiteDto UpdateSite(Guid id, SiteForUpdateDto site, bool trackChanges);
    }
}
