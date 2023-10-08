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
            
            var client = new MongoClient("mongodb+srv://sugandhi:EP7ZKYIQ43cBQVDV@cluster0.amprpac.mongodb.net/?retryWrites=true&w=majority"); 
            var database = client.GetDatabase("eadprojectwdb"); 
            
            _trainCollection = database.GetCollection<Train>("Trains"); 
        }

        public IEnumerable<Train> GetTrains()
        {
            return _trainCollection.Find(_ => true).ToList();
        }

        public Train GetTrainById(Guid id)
        {
            return _trainCollection.Find(train => train.Id == id).FirstOrDefault();
        }

        public void AddTrain(Train train)
        {
            _trainCollection.InsertOne(train);
        }

        public void UpdateTrain(Train train)
        {
            var filter = Builders<Train>.Filter.Eq(t => t.Id, train.Id);
            var update = Builders<Train>.Update
                .Set(t => t.TrainName, train.TrainName)
                .Set(t => t.DepartureCity, train.DepartureCity)
                .Set(t => t.ArrivalCity, train.ArrivalCity);

            _trainCollection.UpdateOne(filter, update);
        }

        public void DeleteTrain(Guid id)
        {
            var filter = Builders<Train>.Filter.Eq(t => t.Id, id);
            _trainCollection.DeleteOne(filter);
        }
    }
}
