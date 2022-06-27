﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WMS.Service.Dtos.Floor;
using WMS.Service.Dtos.Site;
using WMS.Service.Interfaces;

namespace WMS.Web.Controllers
{
    [Route("api/sites/{siteId}/floors")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IFloorsService _floorsService;
        private ISitesService _sitesService;

        public FloorsController(
            ILoggerManager logger, 
            IFloorsService floorsService,
            ISitesService sitesService)
        {
            _logger = logger;
            _floorsService = floorsService;
            _sitesService = sitesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFloorsForSite(Guid siteId)
        {
            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database");
                return NotFound();
            }

            IEnumerable<FloorDto> floors = await _floorsService.GetFloors(siteId, trackChanges: false);

            return Ok(floors);
        }

        [HttpGet("{id}", Name = "GetFloorForSite")]
        public async Task<IActionResult> GetFloorForSite(Guid siteId, Guid id)
        {
            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floor = await _floorsService.GetFloor(siteId, id, trackChanges: false);
            if (floor == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            return Ok(floor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloorForSite(Guid siteId, [FromBody] FloorForCreationDto floor)
        {
            if (floor == null)
            {
                _logger.LogError("FloorForCreationDto object sent from client is null.");
                return BadRequest("FloorForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FloorForCreationDto object");
                ModelState.AddModelError("test", "test 2"); // add custom error message
                return UnprocessableEntity(ModelState);
            }

            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToReturn = await _floorsService.CreateFloor(siteId, floor);

            return CreatedAtRoute("GetFloorForSite", new { siteId, id = floorToReturn.Id }, floorToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloorForSite(Guid siteId, Guid id)
        {
            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);

            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database");
                return NotFound();
            }

            FloorDto floorForSite = await _floorsService.GetFloor(siteId, id, trackChanges: false);

            if (floorForSite == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database");
                return NotFound();
            }

            await _floorsService.DeleteFloor(siteId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFloorForSite(Guid siteId, Guid id, [FromBody] FloorForUpdateDto floor)
        {
            if (floor == null)
            {
                _logger.LogError("FloorForUpdateDto object sent from client is null.");
                return BadRequest("FloorForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the FloorForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToBeUpdated = await _floorsService.GetFloor(siteId, id, trackChanges: false);
            if (floorToBeUpdated == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            await _floorsService.UpdateFloorForSite(siteId, id, floor, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateFloorForSite(Guid siteId, Guid id, [FromBody] JsonPatchDocument<FloorForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            SiteDto site = await _sitesService.GetSite(siteId, trackChanges: false);
            if (site == null)
            {
                _logger.LogInfo($"Site with id: {siteId} doesn't exist in the database.");
                return NotFound();
            }

            FloorDto floorToBeUpdated = await _floorsService.GetFloor(siteId, id, trackChanges: false);

            if (floorToBeUpdated == null)
            {
                _logger.LogInfo($"Floor with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            // validation cannot be made due to architecture failure, see the book

            await _floorsService.PartiallyUpdateFloorForSite(siteId, id, patchDoc, true);

            return NoContent();
        }
    }
}
