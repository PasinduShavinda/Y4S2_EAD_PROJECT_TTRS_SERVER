

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TravelEase_WebService.SheduleModels;

namespace TravelEase_WebService.Dtos.TrainSheduleManagemet
{
    public class SheduleService : IScheduleService
    {
        private readonly IMongoCollection<Schedule> _scheduleCollection;

        public SheduleService()
        {
            var client = new MongoClient("mongodb+srv://sugandhi:EP7ZKYIQ43cBQVDV@cluster0.amprpac.mongodb.net/?retryWrites=true&w=majority"); // Replace with your MongoDB connection string
            var database = client.GetDatabase("eadprojectwdb");

            _scheduleCollection = database.GetCollection<Schedule>("Schedules"); // Replace "Schedules" with your collection name
        }

        public IEnumerable<Schedule> GetShedules()
        {
            return _scheduleCollection.Find(_ => true).ToList();
        }

        public Schedule GetSheduleById(Guid id)
        {
            return _scheduleCollection.Find(schedule => schedule.Id == id).FirstOrDefault();
        }

        public void AddShedule(Schedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            _scheduleCollection.InsertOne(schedule);
        }

        public void UpdateShedule(Schedule schedule)
        {
            var filter = Builders<Schedule>.Filter.Eq(s => s.Id, schedule.Id);
            var update = Builders<Schedule>.Update
                .Set(s => s.TrainName, schedule.TrainName)
                .Set(s => s.DepartureCity, schedule.DepartureCity)
                .Set(s => s.ArrivalCity, schedule.ArrivalCity);

            _scheduleCollection.UpdateOne(filter, update);
        }

        public void DeleteShedule(Guid id)
        {
            var filter = Builders<Schedule>.Filter.Eq(s => s.Id, id);
            _scheduleCollection.DeleteOne(filter);
        }

        public IEnumerable<Schedule> GetSchedulesByTrainId(string trainId)
        {
            return _scheduleCollection.Find(schedule => schedule.TrainId == trainId).ToList();
        }
    }
}
