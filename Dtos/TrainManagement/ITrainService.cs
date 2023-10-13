////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ITrainService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Train service interface defining methods for train management
////////////////////////////////////////////////////////////////////////////////////////////////////////

using TravelEase_WebService.TrainModels;

namespace TravelEase_WebService.Dtos.TrainService
{
    // This interface defines the contract for managing train details.
    public interface ITrainService
    {
        // Retrieves a list of all trains.
        IEnumerable<Train> GetTrains();

        // Retrieves a train by its unique identifier.
        Train GetTrainById(Guid id);

        // Adds a new train to the system.
        void AddTrain(Train train);

        // Updates an existing train with the provided data.
        void UpdateTrain(Train train);

        // Deletes a train based on its unique identifier.
        void DeleteTrain(Guid id);
    }
}

