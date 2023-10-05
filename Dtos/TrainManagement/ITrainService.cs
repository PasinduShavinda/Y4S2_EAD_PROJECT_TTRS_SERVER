//namespace TravelEase_WebService.Dtos.TrainManagement

// Services/ITrainService.cs
// Services/ITrainService.cs
using System;
using System.Collections.Generic;
using TravelEase_WebService.TrainModels;

namespace TravelEase_WebService.Services
{
    public interface ITrainService
    {
        IEnumerable<Train> GetTrains();
        Train GetTrainById(Guid id);
        void AddTrain(Train train);
        void UpdateTrain(Train train);
        void DeleteTrain(Guid id);
    }
}

