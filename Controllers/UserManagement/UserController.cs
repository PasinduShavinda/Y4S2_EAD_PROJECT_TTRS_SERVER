using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.Services;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace TravelEase_WebService.Controllers.UserManagement;

//[Authorize(Roles = "Back Officer, Travel Agent")]
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

        var filter = Builders<RegisteredTravellerModel>.Filter.Ne(x => x.Nic, "");

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

}



