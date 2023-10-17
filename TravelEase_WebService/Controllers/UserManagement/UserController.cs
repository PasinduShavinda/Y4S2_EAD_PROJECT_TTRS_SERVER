////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: UserController.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Controller for managing registered travelers.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace TravelEase_WebService.Controllers.UserManagement
{
    [Authorize(Roles = "Back Officer, Travel Agent")]
    [ApiController]
    [Route("api/v1/regtravellers")]
    public class UserController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public UserController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        /// <summary>
        /// Get a list of registered travelers.
        /// </summary>
        /// <returns>A list of registered traveler profiles.</returns>
        [HttpGet]
        [Route("view")]
        public async Task<List<RegisteredTravellerModel>> Get()
        {
            // Filter out documents with an empty NIC field
            var filter = Builders<RegisteredTravellerModel>.Filter.Ne(x => x.Nic, "");

            // Define a projection to exclude sensitive information
            var projection = Builders<RegisteredTravellerModel>.Projection
                .Exclude("NormalizedUserName")
                .Exclude("NormalizedEmail")
                .Exclude("EmailConfirmed")
                .Exclude("PasswordHash")
                .Exclude("SecurityStamp")
                .Exclude("ConcurrencyStamp")
                .Exclude("PhoneNumber")
                .Exclude("PhoneNumberConfirmed")
                .Exclude("TwoFactorEnabled")
                .Exclude("LockoutEnd")
                .Exclude("LockoutEnabled")
                .Exclude("AccessFailedCount")
                .Exclude("Version")
                .Exclude("CreatedOn")
                .Exclude("Claims")
                .Exclude("Logins")
                .Exclude("Tokens");

            // Retrieve registered traveler profiles
            var users = await _mongoDBService.GetRegTravAsync(filter, projection);

            return users;
        }

        /// <summary>
        /// Get a registered traveler by NIC (National Identity Card).
        /// </summary>
        /// <param name="Nic">The NIC of the registered traveler to retrieve.</param>
        /// <returns>An IActionResult representing the retrieved registered traveler profile.</returns>
        [HttpGet("view/{Nic}")]
        public async Task<IActionResult> GetById(string Nic)
        {
            // Define a projection to exclude sensitive information
            var projection = Builders<RegisteredTravellerModel>.Projection
                .Exclude("NormalizedUserName")
                .Exclude("NormalizedEmail")
                .Exclude("EmailConfirmed")
                .Exclude("PasswordHash")
                .Exclude("SecurityStamp")
                .Exclude("ConcurrencyStamp")
                .Exclude("PhoneNumber")
                .Exclude("PhoneNumberConfirmed")
                .Exclude("TwoFactorEnabled")
                .Exclude("LockoutEnd")
                .Exclude("LockoutEnabled")
                .Exclude("AccessFailedCount")
                .Exclude("Version")
                .Exclude("CreatedOn")
                .Exclude("Claims")
                .Exclude("Logins")
                .Exclude("Tokens");

            // Retrieve the registered traveler profile by NIC
            var acc = await _mongoDBService.GetRegTravByIdAsync(Nic, projection);

            return Ok(acc);
        }

        /// <summary>
        /// Set the profile crated state - true
        /// </summary>
        [HttpPut("setprofile/{Nic}")]
        public async Task<IActionResult> SetProfile(string Nic)
        {
            var profileSet = await _mongoDBService.SetProfileState(Nic);

            if (profileSet)
            {
                return Ok(new { message = "Traveller profile state updated." });
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Set the profile crated state - false
        /// </summary>
        [HttpPut("setprofile2/{Nic}")]
        public async Task<IActionResult> SetProfile2(string Nic)
        {
            var profileSet = await _mongoDBService.SetProfileState2(Nic);

            if (profileSet)
            {
                return Ok(new { message = "Traveller account state updated." });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
