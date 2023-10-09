using TravelEase_WebService.Models.DBSettings;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;

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

    //public async Task CreateAsync(string NIC, TravellerProfileModel travellerProfileModel)
    //{
    //    // First, retrieve the RegisteredTraveller by Nic
    //    var registeredTraveller = await _registeredTravellerCollection
    //        .Find(x => x.Nic == NIC)
    //        .FirstOrDefaultAsync();

    //    if (registeredTraveller != null)
    //    {
    //        // Now, create a TravellerProfileModel by merging information
    //        var newTravellerProfile = new TravellerProfileModel
    //        {
    //            NIC = NIC, // Use the selectedNic parameter
    //            FullName = registeredTraveller.FullName,
    //            UserName = registeredTraveller.UserName,
    //            Email = registeredTraveller.Email,
    //            IsActive = registeredTraveller.IsActive,


    //            // Set other properties like Gender, DOB, Nationality
    //            Gender = travellerProfileModel.Gender,
    //            DOB = travellerProfileModel.DOB,
    //            Nationality = travellerProfileModel.Nationality,
    //            ContactNumber = travellerProfileModel.ContactNumber,
    //            Address = travellerProfileModel.Address,
    //            PassportNumber = travellerProfileModel.PassportNumber,
    //            PrefferedLanguage = travellerProfileModel.PrefferedLanguage,
    //            EmergencyContactName = travellerProfileModel.EmergencyContactName,
    //            RelationshipToTraveller = travellerProfileModel.RelationshipToTraveller,
    //            EmergencyContactNumber = travellerProfileModel.EmergencyContactNumber,
    //        };

    //        await _travellerProfilesCollection.InsertOneAsync(newTravellerProfile);
    //    }
    //    else
    //    {
    //        throw new Exception("RegisteredTraveller not found by Nic.");
    //    }
    //}


    // GET
    public async Task<List<TravellerProfileModel>> GetAsync()
    {
        return await _travellerProfilesCollection.Find(new BsonDocument()).ToListAsync();
    }

    // GET BY ID
    public async Task<TravellerProfileModel> GetByIdAsync(string id)
    {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("Id", id);
        return await _travellerProfilesCollection.Find(filter).FirstOrDefaultAsync();
    }

    // UPDATE
    public async Task<bool> UpdateAsync(string id, TravellerProfileModel updatedProfile)
    {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("Id", id);

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
    public async Task DeleteAsync(string id) {
        FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("Id", id);
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
        //var filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);
        FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);
        var query = _registeredTravellerCollection.Find(filter);

        if (projection != null)
        {
            query = query.Project(projection);
        }

        return await query.FirstOrDefaultAsync();
    }


    //// UPDATE
    //public async Task UpdateAsync(string id, string movieId)
    //{
    //    FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("Id", id);
    //    UpdateDefinition<TravellerProfileModel> update = Builders<TravellerProfileModel>.Update.AddToSet<string>("movieId", movieId);
    //    await _travellerProfilesCollection.UpdateOneAsync(filter, update);
    //}

}


