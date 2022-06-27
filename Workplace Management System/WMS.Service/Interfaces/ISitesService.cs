using WMS.Service.Dtos.Site;

namespace WMS.Service.Interfaces
{
    public interface ISitesService
    {
        Task DeleteSite(Guid id, bool trackChanges);

        Task<IEnumerable<SiteDto>> GetSites(bool trackChanges);

        Task<SiteDto> GetSite(Guid id, bool trackChanges);

        Task<SiteDto> CreateSite(SiteForCreationDto site);

        Task<IEnumerable<SiteDto>> GetSiteCollection(IEnumerable<Guid> ids, bool trackChanges);

        Task<IEnumerable<SiteDto>> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection);

        Task<SiteDto> UpdateSite(Guid id, SiteForUpdateDto site, bool trackChanges);
    }
}
