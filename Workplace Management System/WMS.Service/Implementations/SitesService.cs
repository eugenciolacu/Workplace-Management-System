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

        public IEnumerable<SiteDto> GetAllSites(bool trackChanges)
        {
            IEnumerable<Site> sites = _repository.Site.GetAllSites(trackChanges);

            IEnumerable<SiteDto> sitesDtos = _mapper.Map<IEnumerable<SiteDto>>(sites);

            return sitesDtos;
        }

        public SiteDto GetSite(Guid id, bool trackChanges)
        {
            Site site = _repository.Site.GetSite(id, trackChanges);

            SiteDto siteDto = _mapper.Map<SiteDto>(site);

            return siteDto;
        }
    }
}
