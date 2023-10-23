////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ScheduleService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: TrainSchedules service for managing train schedules using MongoDB
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TravelEase_WebService.SheduleModels;

namespace TravelEase_WebService.Dtos.TrainSheduleManagemet
{
    public class ScheduleService : IScheduleService
    {
        private readonly IMongoCollection<Schedule> _scheduleCollection;

        public ScheduleService()
        {
            // Initialize the MongoDB collection for train schedules.
            var client = new MongoClient("mongodb+srv://it20140298:eadpw123zx@eadcluster.jwo16r4.mongodb.net/?retryWrites=true&w=majority"); // Replace with your MongoDB connection string
            var database = client.GetDatabase("eadprojectwdb");

            _scheduleCollection = database.GetCollection<Schedule>("Schedules"); // Replace "Schedules" with your collection name
        }

        // Retrieve a list of all schedules.
        public IEnumerable<Schedule> GetShedules()
        {
            return _scheduleCollection.Find(_ => true).ToList();
        }

        // Retrieve a schedule by its unique identifier.
        public Schedule GetSheduleById(Guid id)
        {
            return _scheduleCollection.Find(schedule => schedule.Id == id).FirstOrDefault();
        }

        // Add a new schedule to the system.
        public void AddShedule(Schedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            _scheduleCollection.InsertOne(schedule);
        }

        // Update an existing schedule with the provided data.
        public void UpdateShedule(Schedule schedule)
        {
            var filter = Builders<Schedule>.Filter.Eq(s => s.Id, schedule.Id);
            var update = Builders<Schedule>.Update
                .Set(s => s.reserved1seates, schedule.reserved1seates)
                .Set(s => s.reserved2seates, schedule.reserved2seates)
                .Set(s => s.Date, schedule.Date)
                .Set(s => s.ArrivalCity, schedule.ArrivalCity)
                .Set(s => s.Arrivaltime, schedule.Arrivaltime)
                .Set(s => s.DepartureCity, schedule.DepartureCity)
                 .Set(s => s.Departuretime, schedule.Departuretime)
                .Set(s => s.StopStations, schedule.StopStations)
                .Set(s => s.TrainName, schedule.TrainName)
                .Set(s => s.class1reservation, schedule.class1reservation)
                .Set(s => s.class2reservation, schedule.class2reservation);

            _scheduleCollection.UpdateOne(filter, update);
        }

        // Delete a schedule based on its unique identifier.
        public void DeleteShedule(Guid id)
        {
            var filter = Builders<Schedule>.Filter.Eq(s => s.Id, id);
            _scheduleCollection.DeleteOne(filter);
        }

        // Retrieve a list of schedules associated with a specific train.
        public IEnumerable<Schedule> GetSchedulesByTrainId(string trainId)
        {
            return _scheduleCollection.Find(schedule => schedule.TrainId == trainId).ToList();
        }
    }
}
