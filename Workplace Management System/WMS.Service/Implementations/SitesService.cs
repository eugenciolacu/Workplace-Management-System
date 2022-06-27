using AutoMapper;
using WMS.Data.Entities.Core;
using WMS.Repository.Repositories.Interfaces;
using WMS.Service.Dtos.Site;
using WMS.Service.Interfaces;

namespace WMS.Service.Implementations
{
    public class SitesService : ISitesService
    {
        private readonly IRepositoryManager _repository = null!;
        private ILoggerManager _logger = null!;
        private IMapper _mapper = null!;

        public SitesService(
            IRepositoryManager repository, 
            ILoggerManager logger, 
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task DeleteSite(Guid id, bool trackChanges)
        {
            Site site = await _repository.Site.GetSiteAsync(id, trackChanges);

            _repository.Site.DeleteSite(site);

            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<SiteDto>> GetSites(bool trackChanges)
        {
            IEnumerable<Site> sites = await _repository.Site.GetSitesAsync(trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

            return sitesDtos;
        }

        public async Task<SiteDto> GetSite(Guid id, bool trackChanges)
        {
            Site site = await _repository.Site.GetSiteAsync(id, trackChanges);

            SiteDto siteDto = _mapper.Map<SiteDto>(site);

            return siteDto;
        }

        public async Task<SiteDto> CreateSite(SiteForCreationDto site)
        {
            Site siteEntity = _mapper.Map<Site>(site);

            _repository.Site.CreateSite(siteEntity);

            await _repository.SaveAsync();

            return _mapper.Map<SiteDto>(siteEntity);
        }

        public async Task<IEnumerable<SiteDto>> GetSiteCollection(IEnumerable<Guid> ids, bool trackChanges)
        {
            IEnumerable<Site> siteEntities = await _repository.Site.GetByIdsAsync(ids, trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(siteEntities);

            return sitesDtos;
        }

        public async Task<IEnumerable<SiteDto>> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection)
        {
            IEnumerable<Site> siteEntities = _mapper.Map<IEnumerable<Site>>(siteCollection);

            foreach (Site site in siteEntities)
            {
                _repository.Site.CreateSite(site);
            }

            await _repository.SaveAsync();

            return _mapper.Map<IEnumerable<SiteDto>>(siteEntities);
        }

        public async Task<SiteDto> UpdateSite(Guid id, SiteForUpdateDto site, bool trackChanges)
        {
            var siteEntity = await _repository.Site.GetSiteAsync(id, trackChanges);

            _mapper.Map(site, siteEntity);

            await _repository.SaveAsync();

            return _mapper.Map<SiteDto>(siteEntity);
        }
    }
}
