using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMS.Data.Entities;
using WMS.Service.Dtos.Site;
using WMS.Service.Interfaces;
using WMS.Service.ModelBinders;
using WMS.Web.ActionFilters;

namespace WMS.Web.Controllers
{
    [Route("api/sites")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")] // used by swagger
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

        /// <summary> 
        /// Gets the list of all sites 
        /// </summary> 
        /// <returns>The sites list</returns>
        [HttpGet(Name = "GetSites"), Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> GetSites()
        {
            var sites = await _sitesService.GetSites(trackChanges: false);

            return Ok(sites);
        }

        [HttpGet("{id}", Name = "SiteById"), Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetSite(Guid id)
        {
            SiteDto site = await _sitesService.GetSite(id, trackChanges: false);
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateSite([FromBody] SiteForCreationDto site)
        {
            //if (site == null)
            //{
            //    _logger.LogError("SiteForCreationDto object sent from client is null");
            //    return BadRequest("SiteForCreationDto object is null");
            //}

            SiteDto siteToReturn = await _sitesService.CreateSite(site);

            return CreatedAtRoute("SiteById", new { id = siteToReturn.Id }, siteToReturn);
        }

        [HttpGet("collection/({ids})", Name = "SiteCollection")]
        public async Task<IActionResult> GetSiteCollection([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids) // without [FromRoute] do not work in swagger
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            IEnumerable<SiteDto> sitesToReturn = await _sitesService.GetSiteCollection(ids, trackChanges: false);

            if (ids.Count() != sitesToReturn.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            return Ok(sitesToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateSiteCollection([FromBody] IEnumerable<SiteForCreationDto> siteCollection)
        {
            if (siteCollection == null)
            {
                _logger.LogError("Site collection sent from client is null.");
                return BadRequest("Site collection is null");
            }

            IEnumerable<SiteDto> siteCollectionToReturn = await _sitesService.CreateSiteCollection(siteCollection);

            var ids = string.Join(",", siteCollectionToReturn.Select(s => s.Id));

            return CreatedAtRoute("SiteCollection", new { ids }, siteCollectionToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(Guid id)
        {
            var site = await _sitesService.GetSite(id, trackChanges: false);

            if (site == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            await _sitesService.DeleteSite(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSite(Guid id, [FromBody] SiteForUpdateDto site)
        {
            //if (site == null)
            //{
            //    _logger.LogError("SiteForUpdateDto object sent from client is null.");
            //    return BadRequest("SiteForUpdate object is null");
            //}

            SiteDto siteToBeUpdated = await _sitesService.GetSite(id, false);
            if (siteToBeUpdated == null)
            {
                _logger.LogInfo($"Site with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            await _sitesService.UpdateSite(id, site, trackChanges: true);

            return NoContent();
        }
    }
}
