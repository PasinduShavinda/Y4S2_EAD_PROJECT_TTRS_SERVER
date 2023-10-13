////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: IScheduleService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: TrainSchedules service interface defining methods for schedule management
////////////////////////////////////////////////////////////////////////////////////////////////////////

using TravelEase_WebService.SheduleModels;

namespace TravelEase_WebService.Dtos.TrainSheduleManagemet
{
    // This interface defines the contract for managing train schedules.
    public interface IScheduleService
    {
        // Retrieves a list of all schedules.
        IEnumerable<Schedule> GetShedules();

        // Retrieves a schedule by its unique identifier.
        Schedule GetSheduleById(Guid id);

        // Adds a new schedule to the system.
        void AddShedule(Schedule shedule);

        // Updates an existing schedule with the provided data.
        void UpdateShedule(Schedule shedule);

        // Deletes a schedule based on its unique identifier.
        void DeleteShedule(Guid id);

        // Retrieves a list of schedules associated with a specific train.
        IEnumerable<Schedule> GetSchedulesByTrainId(string trainId);
    }
}

