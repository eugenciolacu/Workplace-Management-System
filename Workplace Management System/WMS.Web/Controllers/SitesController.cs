using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Service.Dtos.Site;
using WMS.Service.Interfaces;

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
        public IActionResult GetAllSites()
        {
            var sites = _sitesService.GetAllSites(trackChanges: false);

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
    }
}
