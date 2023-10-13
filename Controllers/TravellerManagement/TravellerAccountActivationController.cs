////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TravellerAccountActivationController.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Controller for managing traveler profiles and account activation.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement
{
    [Authorize(Roles = "Back Officer")]
    [ApiController]
    [Route("api/v1/traveller/account")]
    public class ProfileActivationController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public ProfileActivationController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        /// <summary>
        /// Activates a traveler's account by NIC.
        /// </summary>
        /// <param name="Nic">The NIC (National Identity Card) of the traveler to activate.</param>
        /// <returns>An IActionResult representing the result of the activation operation.</returns>
        [HttpPut("activate/{Nic}")]
        public async Task<IActionResult> Activate(string Nic)
        {
            var activated = await _mongoDBService.ActivateAsync(Nic);

            if (activated)
            {
                return Ok(new { message = "Traveller Account has been Activated." });
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deactivates a traveler's account by NIC.
        /// </summary>
        /// <param name="Nic">The NIC (National Identity Card) of the traveler to deactivate.</param>
        /// <returns>An IActionResult representing the result of the deactivation operation.</returns>
        [HttpPut("deactivate/{Nic}")]
        public async Task<IActionResult> Deactivate(string Nic)
        {
            var deactivated = await _mongoDBService.DeactivateAsync(Nic);

            if (deactivated)
            {
                return Ok(new { message = "Traveller Account has been Deactivated." });
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Sends a request to the Back Officer to re-activate a traveler's account by NIC.
        /// </summary>
        /// <param name="Nic">The NIC (National Identity Card) of the traveler to send the re-activation request.</param>
        /// <returns>An IActionResult representing the result of the request sending operation.</returns>
        [HttpPut("sendreq/{Nic}")]
        public async Task<IActionResult> SendReq(string Nic)
        {
            var reqsent = await _mongoDBService.SendRequestAsync(Nic);

            if (reqsent)
            {
                return Ok(new { message = "Request Sent to the Back Officer to Re-Activate." });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
