////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TrainService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Train services for managing train details using MongoDB
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using MongoDB.Driver;
using TravelEase_WebService.TrainModels;

namespace TravelEase_WebService.Dtos.TrainService
{
    public class TrainService : ITrainService
    {
        private readonly IMongoCollection<Train> _trainCollection;

        public TrainService()
        {
            // Initialize the MongoDB collection for train details.
            var client = new MongoClient("mongodb+srv://sugandhi:EP7ZKYIQ43cBQVDV@cluster0.amprpac.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("eadprojectwdb");
            _trainCollection = database.GetCollection<Train>("Trains");
        }

        // Retrieve a list of all trains.
        public IEnumerable<Train> GetTrains()
        {
            return _trainCollection.Find(_ => true).ToList();
        }

        // Retrieve a train by its unique identifier.
        public Train GetTrainById(Guid id)
        {
            return _trainCollection.Find(train => train.Id == id).FirstOrDefault();
        }

        // Add a new train to the system.
        public void AddTrain(Train train)
        {
            _trainCollection.InsertOne(train);
        }

        // Update an existing train with the provided data.
        public void UpdateTrain(Train train)
        {
            var filter = Builders<Train>.Filter.Eq(t => t.Id, train.Id);
            var update = Builders<Train>.Update
                .Set(t => t.TrainName, train.TrainName)
                .Set(t => t.DepartureCity, train.DepartureCity)
                .Set(t => t.ArrivalCity, train.ArrivalCity);

            _trainCollection.UpdateOne(filter, update);
        }

        // Delete a train based on its unique identifier.
        public void DeleteTrain(Guid id)
        {
            var filter = Builders<Train>.Filter.Eq(t => t.Id, id);
            _trainCollection.DeleteOne(filter);
        }
    }
}
