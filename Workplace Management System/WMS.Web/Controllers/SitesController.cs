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
        private ISiteService _siteService;

        public SitesController(
            ILoggerManager logger, 
            ISiteService siteService)
        {
            _logger = logger;
            _siteService = siteService;
        }

        [HttpGet]
        public IActionResult GetAllSites()
        {
            IEnumerable<SiteDto> sites = _siteService.GetAllSites(trackChanges: false);

            return Ok(sites);
        }
    }
}
