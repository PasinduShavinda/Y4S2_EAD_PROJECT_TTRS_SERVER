using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement;

[Authorize(Roles = "BACK_OFFICER")]
[ApiController]
[Route("api/v1/traveller/profile")]
public class ProfileActivationController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public ProfileActivationController(MongoDBService mongoDBService)
    {

        _mongoDBService = mongoDBService;
    }

    [HttpPut("{id}/activate")]
    public async Task<IActionResult> Activate(string id)
    {

        var activated = await _mongoDBService.ActivateAsync(id);

        if (activated)
        {
            return Ok(new { message = "Traveller Profile has been activated." });
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(string id)
    {

        var deactivated = await _mongoDBService.DeactivateAsync(id);

        if (deactivated)
        {
            return Ok(new { message = "Traveller Profile has been deactivated." });
        }
        else
        {
            return NotFound();
        }
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(string id, [FromBody] string movieId) {
    //    await _mongoDBService.UpdateAsync(id, movieId);
    //    return NoContent();
    //}
}
