using TravelEase_WebService.Models.DBSettings;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TravelEase_WebService.Services;

public class MongoDBService
{
    private readonly IMongoCollection<TravellerProfileModel> _travellerProfilesCollection;
    private readonly IMongoCollection<RegisteredTravellerModel> _registeredTravellerCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _travellerProfilesCollection = database.GetCollection<TravellerProfileModel>(mongoDBSettings.Value.CollectionName1);
        _registeredTravellerCollection = database.GetCollection<RegisteredTravellerModel>(mongoDBSettings.Value.CollectionName2);

    }

    // CREATE
    public async Task CreateAsync(TravellerProfileModel travellerProfileModel)
    {

        await _travellerProfilesCollection.InsertOneAsync(travellerProfileModel);
        return;

    }

    // GET
    public async Task<List<TravellerProfileModel>> GetAsync()
    {
        return await _travellerProfilesCollection.Find(new BsonDocument()).ToListAsync();
    }

    // GET BY ID
    public async Task<TravellerProfileModel> GetByIdAsync(string NIC)
    {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("NIC", NIC);
        return await _travellerProfilesCollection.Find(filter).FirstOrDefaultAsync();
    }

    // UPDATE
    public async Task<bool> UpdateAsync(string NIC, TravellerProfileModel updatedProfile)
    {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("NIC", NIC);

        UpdateDefinition<TravellerProfileModel> update = Builders<TravellerProfileModel>.Update
            .Set("FullName", updatedProfile.FullName)
            .Set("UserName", updatedProfile.UserName)
            .Set("Gender", updatedProfile.Gender)
            .Set("DOB", updatedProfile.DOB)
            .Set("Nationality", updatedProfile.Nationality)
            .Set("ContactNumber", updatedProfile.ContactNumber)
            .Set("Email", updatedProfile.Email)
            .Set("Address", updatedProfile.Address)
            .Set("NIC", updatedProfile.NIC)
            .Set("PassportNumber", updatedProfile.PassportNumber)
            .Set("PrefferedLanguage", updatedProfile.PrefferedLanguage)
            .Set("EmergencyContactName", updatedProfile.EmergencyContactName)
            .Set("RelationshipToTraveller", updatedProfile.RelationshipToTraveller)
            .Set("EmergencyContactNumber", updatedProfile.EmergencyContactNumber);

        var result = await _travellerProfilesCollection.UpdateOneAsync(filter, update);

        return result.ModifiedCount > 0;
    }


    // Delete
    public async Task DeleteAsync(string NIC) {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("NIC", NIC);
        await _travellerProfilesCollection.DeleteOneAsync(filter);
        return;
    }

    // Activate Traveller Account
    public async Task<bool> ActivateAsync(string Nic)
    {
        FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);

        UpdateDefinition<RegisteredTravellerModel> update = Builders<RegisteredTravellerModel>.Update
            .Set("IsActive", true);

        var result1 = await _registeredTravellerCollection.UpdateOneAsync(filter, update);

        return result1.ModifiedCount > 0;
    }

    // Deactivate Traveller Account
    public async Task<bool> DeactivateAsync(string Nic)
    {
        FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);

        UpdateDefinition<RegisteredTravellerModel> update = Builders<RegisteredTravellerModel>.Update
            .Set("IsActive", false);

        var result2 = await _registeredTravellerCollection.UpdateOneAsync(filter, update);

        return result2.ModifiedCount > 0;
    }

    // Get Registered Traveller Details
    public async Task<List<RegisteredTravellerModel>> GetRegTravAsync(FilterDefinition<RegisteredTravellerModel> filter, ProjectionDefinition<RegisteredTravellerModel, RegisteredTravellerModel> projection)
    {
        var query = _registeredTravellerCollection.Find(filter);

        if (projection != null)
        {
            query = query.Project(projection);
        }

        return await query.ToListAsync();
    }

    // Get Registered Traveller Details By NIC
    public async Task<RegisteredTravellerModel> GetRegTravByIdAsync(string Nic, ProjectionDefinition<RegisteredTravellerModel, RegisteredTravellerModel> projection)
    {
        FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);
        var query = _registeredTravellerCollection.Find(filter);

        if (projection != null)
        {
            query = query.Project(projection);
        }

        return await query.FirstOrDefaultAsync();
    }

}


