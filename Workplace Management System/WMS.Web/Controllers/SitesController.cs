using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WMS.Service.Dtos.Site;
using WMS.Service.Interfaces;
using WMS.Service.ModelBinders;

namespace WMS.Web.Controllers
{
    [Route("api/sites")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private ILoggerManager _logger;
        private ISitesService _sitesService;

        public SitesController(
            ILoggerManager logger, 
            ISitesService sitesService)
        {
            _logger = logger;
            _sitesService = sitesService;
        }

        [HttpGet]
        public IActionResult GetSites()
        {
            var sites = _sitesService.GetSites(trackChanges: false);

            return Ok(sites);
        }

        [HttpGet("{id}", Name = "SiteById")]
        public IActionResult GetSite(Guid id)
        {
            SiteDto site = _sitesService.GetSite(id, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(site);
            }
        }

        [HttpPost]
        public IActionResult CreateSite([FromBody] SiteForCreationDto site)
        {
            if (site == null)
            {
                _logger.LogError("SiteForCreationDto object sent from client is null");
                return BadRequest("SiteForCreationDto object is null");
            }

            SiteDto siteToReturn = _sitesService.CreateSite(site);

            return CreatedAtRoute("SiteById", new { id = siteToReturn.Id }, siteToReturn);
        }

        [HttpGet("collection/({ids})", Name = "SiteCollection")]
        public IActionResult GetSiteCollection([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids) // without [FromRoute] do not work in swagger
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            IEnumerable<SiteDto> sitesToReturn = _sitesService.GetSiteCollection(ids, trackChanges: false);

            if (ids.Count() != sitesToReturn.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            return Ok(sitesToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateSiteCollection([FromBody] IEnumerable<SiteForCreationDto> siteCollection)
        {
            if (siteCollection == null)
            {
                _logger.LogError("Site collection sent from client is null.");
                return BadRequest("Site collection is null");
            }

            IEnumerable<SiteDto> siteCollectionToReturn = _sitesService.CreateSiteCollection(siteCollection);

            var ids = string.Join(",", siteCollectionToReturn.Select(s => s.Id));

            return CreatedAtRoute("SiteCollection", new { ids }, siteCollectionToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSite(Guid id)
        {
            var site = _sitesService.GetSite(id, trackChanges: false);

            if (site == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _sitesService.DeleteSite(id, trackChanges: false);

            return NoContent();
        }
    }
}
