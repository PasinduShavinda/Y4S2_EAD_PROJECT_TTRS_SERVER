using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;

namespace TravelEase_WebService.Controllers.TravellerManagement;

[Authorize(Roles = "Travel Agent")]
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {
        var profile = await _mongoDBService.GetByIdAsync(id);
        return Ok(profile);
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> Post([FromBody] TravellerProfileModel travellerProfileModel) {
        await _mongoDBService.CreateAsync(travellerProfileModel);
        return CreatedAtAction(nameof(Get), new { id = travellerProfileModel.Id }, travellerProfileModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] TravellerProfileModel updatedProfile) {
        await _mongoDBService.UpdateAsync(id, updatedProfile);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(string id, [FromBody] string movieId) {
    //    await _mongoDBService.UpdateAsync(id, movieId);
    //    return NoContent();
    //}
}