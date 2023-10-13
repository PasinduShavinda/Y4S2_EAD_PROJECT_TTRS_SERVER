////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: MongoDBService.cs
// FileType: Visual C# Source file
// Author: IT20140298 Shavinda W.A.P
// Description: Service for managing MongoDB data related to TravelEase WebService.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using TravelEase_WebService.Models.DBSettings;
using TravelEase_WebService.Models.TravellerManagement;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TravelEase_WebService.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<TravellerProfileModel> _travellerProfilesCollection;
        private readonly IMongoCollection<RegisteredTravellerModel> _registeredTravellerCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            // Initialize MongoDB connections and collections.
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _travellerProfilesCollection = database.GetCollection<TravellerProfileModel>(mongoDBSettings.Value.CollectionName1);
            _registeredTravellerCollection = database.GetCollection<RegisteredTravellerModel>(mongoDBSettings.Value.CollectionName2);
        }

        // CREATE: Create a new traveler profile.
        public async Task CreateAsync(TravellerProfileModel travellerProfileModel)
        {
            await _travellerProfilesCollection.InsertOneAsync(travellerProfileModel);
            return;
        }

        // GET: Retrieve all traveler profiles.
        public async Task<List<TravellerProfileModel>> GetAsync()
        {
            return await _travellerProfilesCollection.Find(new BsonDocument()).ToListAsync();
        }

        // GET BY ID: Retrieve a traveler profile by NIC (National Identification Card).
        public async Task<TravellerProfileModel> GetByIdAsync(string NIC)
        {
            FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("NIC", NIC);
            return await _travellerProfilesCollection.Find(filter).FirstOrDefaultAsync();
        }

        // UPDATE: Update an existing traveler profile.
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

        // DELETE: Delete a traveler profile by NIC.
        public async Task DeleteAsync(string NIC)
        {
            FilterDefinition<TravellerProfileModel> filter = Builders<TravellerProfileModel>.Filter.Eq("NIC", NIC);
            await _travellerProfilesCollection.DeleteOneAsync(filter);
            return;
        }

        // ACTIVATE TRAVELLER ACCOUNT: Activate a traveler's account.
        public async Task<bool> ActivateAsync(string Nic)
        {
            FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);

            UpdateDefinition<RegisteredTravellerModel> update = Builders<RegisteredTravellerModel>.Update
                .Set("IsActive", true)
                .Set("IsRequestSent", false);

            var result1 = await _registeredTravellerCollection.UpdateOneAsync(filter, update);

            return result1.ModifiedCount > 0;
        }

        // DEACTIVATE TRAVELLER ACCOUNT: Deactivate a traveler's account.
        public async Task<bool> DeactivateAsync(string Nic)
        {
            FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);

            UpdateDefinition<RegisteredTravellerModel> update = Builders<RegisteredTravellerModel>.Update
                .Set("IsActive", false);

            var result2 = await _registeredTravellerCollection.UpdateOneAsync(filter, update);

            return result2.ModifiedCount > 0;
        }

        // GET REGISTERED TRAVELLER DETAILS: Retrieve registered traveler details based on a filter and projection.
        public async Task<List<RegisteredTravellerModel>> GetRegTravAsync(FilterDefinition<RegisteredTravellerModel> filter, ProjectionDefinition<RegisteredTravellerModel, RegisteredTravellerModel> projection)
        {
            var query = _registeredTravellerCollection.Find(filter);

            if (projection != null)
            {
                query = query.Project(projection);
            }

            return await query.ToListAsync();
        }

        // GET REGISTERED TRAVELLER DETAILS BY NIC: Retrieve registered traveler details by NIC with optional projection.
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

        // SEND REQUEST TO ACTIVATE ACCOUNT: Send a request to activate an account.
        public async Task<bool> SendRequestAsync(string Nic)
        {
            FilterDefinition<RegisteredTravellerModel> filter = Builders<RegisteredTravellerModel>.Filter.Eq("Nic", Nic);

            UpdateDefinition<RegisteredTravellerModel> update = Builders<RegisteredTravellerModel>.Update
                .Set("IsRequestSent", true);

            var result1 = await _registeredTravellerCollection.UpdateOneAsync(filter, update);

            return result1.ModifiedCount > 0;
        }
    }
}
