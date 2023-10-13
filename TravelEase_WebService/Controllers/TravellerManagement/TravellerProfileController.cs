////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TravellerProfileController.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Controller for managing traveler profiles.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement
{
    [Authorize(Roles = "Travel Agent")]
    [ApiController]
    [Route("api/v1/traveller")]
    public class TravellerProfileController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public TravellerProfileController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        /// <summary>
        /// Gets a list of all traveler profiles.
        /// </summary>
        /// <returns>A list of traveler profiles.</returns>
        [HttpGet]
        [Route("view")]
        public async Task<List<TravellerProfileModel>> Get()
        {
            var allProfiles = await _mongoDBService.GetAsync();
            return allProfiles;
        }

        /// <summary>
        /// Gets a traveler profile by NIC (National Identity Card).
        /// </summary>
        /// <param name="NIC">The NIC of the traveler profile to retrieve.</param>
        /// <returns>An IActionResult representing the retrieved traveler profile.</returns>
        [HttpGet("view/{NIC}")]
        public async Task<IActionResult> GetById(string NIC)
        {
            var profile = await _mongoDBService.GetByIdAsync(NIC);
            return Ok(profile);
        }

        /// <summary>
        /// Creates a new traveler profile.
        /// </summary>
        /// <param name="travellerProfileModel">The traveler profile data to save.</param>
        /// <returns>An IActionResult representing the result of the creation operation.</returns>
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Post([FromBody] TravellerProfileModel travellerProfileModel)
        {
            await _mongoDBService.CreateAsync(travellerProfileModel);
            return CreatedAtAction(nameof(Get), new { id = travellerProfileModel.Id }, travellerProfileModel);
        }

        /// <summary>
        /// Updates a traveler profile by NIC (National Identity Card).
        /// </summary>
        /// <param name="NIC">The NIC of the traveler profile to update.</param>
        /// <param name="updatedProfile">The updated traveler profile data.</param>
        /// <returns>An IActionResult representing the result of the update operation.</returns>
        [HttpPut("update/{NIC}")]
        public async Task<IActionResult> Update(string NIC, [FromBody] TravellerProfileModel updatedProfile)
        {
            await _mongoDBService.UpdateAsync(NIC, updatedProfile);
            return NoContent();
        }

        /// <summary>
        /// Deletes a traveler profile by NIC (National Identity Card).
        /// </summary>
        /// <param name="NIC">The NIC of the traveler profile to delete.</param>
        /// <returns>An IActionResult representing the result of the deletion operation.</returns>
        [HttpDelete("delete/{NIC}")]
        public async Task<IActionResult> Delete(string NIC)
        {
            await _mongoDBService.DeleteAsync(NIC);
            return NoContent();
        }
    }
}
