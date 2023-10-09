using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement;

//[Authorize(Roles = "Back Officer")]
[ApiController]
[Route("api/v1/traveller/account")]
public class ProfileActivationController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public ProfileActivationController(MongoDBService mongoDBService)
    {

        _mongoDBService = mongoDBService;
    }

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

}
