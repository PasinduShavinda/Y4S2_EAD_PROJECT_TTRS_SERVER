using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace TravelEase_WebService.Controllers.UserManagement;

//[Authorize(Roles = "Back Officer")]
[ApiController]
[Route("api/v1/regtravellers")]
public class UserController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public UserController(MongoDBService mongoDBService)
    {

        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    [Route("view")]
    public async Task<List<RegisteredTravellerModel>> Get()
    {

        var filter = Builders<RegisteredTravellerModel>.Filter.Exists(x => x.Nic, true);

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

        var users = await _mongoDBService.GetRegTravAsync(filter, projection); 

        return users;

    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(string id)
    //{
    //    var profile = await _mongoDBService.GetByIdAsync(id);
    //    return Ok(profile);
    //}

    //[HttpPost]
    //[Route("save")]
    //public async Task<IActionResult> Post([FromBody] TravellerProfileModel travellerProfileModel)
    //{
    //    await _mongoDBService.CreateAsync(travellerProfileModel);
    //    return CreatedAtAction(nameof(Get), new { id = travellerProfileModel.Id }, travellerProfileModel);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(string id, [FromBody] TravellerProfileModel updatedProfile)
    //{
    //    await _mongoDBService.UpdateAsync(id, updatedProfile);
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(string id)
    //{
    //    await _mongoDBService.DeleteAsync(id);
    //    return NoContent();
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Update(string id, [FromBody] string movieId) {
    //    await _mongoDBService.UpdateAsync(id, movieId);
    //    return NoContent();
    //}
}



