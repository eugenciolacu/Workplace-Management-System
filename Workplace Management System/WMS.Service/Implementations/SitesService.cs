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

        public void DeleteSite(Guid id, bool trackChanges)
        {
            Site site = _repository.Site.GetSite(id, trackChanges);

            _repository.Site.DeleteSite(site);

            _repository.Save();
        }

        public IEnumerable<SiteDto> GetSites(bool trackChanges)
        {
            IEnumerable<Site> sites = _repository.Site.GetSites(trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

            return sitesDtos;
        }

        public SiteDto GetSite(Guid id, bool trackChanges)
        {
            Site site = _repository.Site.GetSite(id, trackChanges);

            SiteDto siteDto = _mapper.Map<SiteDto>(site);

            return siteDto;
        }

        public SiteDto CreateSite(SiteForCreationDto site)
        {
            Site siteEntity = _mapper.Map<Site>(site);

            _repository.Site.CreateSite(siteEntity);

            _repository.Save();

            return _mapper.Map<SiteDto>(siteEntity);
        }

        public IEnumerable<SiteDto> GetSiteCollection(IEnumerable<Guid> ids, bool trackChanges)
        {
            IEnumerable<Site> siteEntities = _repository.Site.GetByIds(ids, trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(siteEntities);

            return sitesDtos;
        }

        public IEnumerable<SiteDto> CreateSiteCollection(IEnumerable<SiteForCreationDto> siteCollection)
        {
            IEnumerable<Site> siteEntities = _mapper.Map<IEnumerable<Site>>(siteCollection);

            foreach (Site site in siteEntities)
            {
                _repository.Site.CreateSite(site);
            }

            _repository.Save();

            return _mapper.Map<IEnumerable<SiteDto>>(siteEntities);
        }
    }
}
