using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement;

//[Authorize(Roles = "Travel Agent")]
[ApiController]
[Route("api/v1/traveller")]
public class TravellerProfileController : Controller {

    private readonly MongoDBService _mongoDBService;

    public TravellerProfileController(MongoDBService mongoDBService) {

        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    [Route("view")]
    public async Task<List<TravellerProfileModel>> Get() {
        var allProfiles = await _mongoDBService.GetAsync();
        return allProfiles;
    }

    [HttpGet("view/{NIC}")]
    public async Task<IActionResult> GetById(string NIC) {
        var profile = await _mongoDBService.GetByIdAsync(NIC);
        return Ok(profile);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> Post([FromBody] TravellerProfileModel travellerProfileModel)
    {
        await _mongoDBService.CreateAsync(travellerProfileModel);
        return CreatedAtAction(nameof(Get), new { id = travellerProfileModel.Id }, travellerProfileModel);
    }


    [HttpPut("update/{NIC}")]
    public async Task<IActionResult> Update(string NIC, [FromBody] TravellerProfileModel updatedProfile) {
        await _mongoDBService.UpdateAsync(NIC, updatedProfile);
        return NoContent();
    }

    [HttpDelete("delete/{NIC}")]
    public async Task<IActionResult> Delete(string NIC) {
        await _mongoDBService.DeleteAsync(NIC);
        return NoContent();
    }

}