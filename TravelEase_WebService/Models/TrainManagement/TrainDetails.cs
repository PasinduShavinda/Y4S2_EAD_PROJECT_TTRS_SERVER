////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TrainDetails.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: DB model class for train details
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TravelEase_WebService.TrainModels
{
    public class Train
    {
        // Unique identifier for the train.
        public Guid Id { get; set; }

        // The name of the train.
        public string TrainName { get; set; }

        // The departure city for the train.
        public string DepartureCity { get; set; }

        // The arrival city for the train.
        public string ArrivalCity { get; set; }

        // The departure time of the train.
        public string Departuretime { get; set; }

        // The arrival time of the train.
        public string Arrivaltime { get; set; }

        // Reservation details for class 1 (e.g., availability).
        public string class1reservation { get; set; }

        // Reservation details for class 2 (e.g., availability).
        public string class2reservation { get; set; }

        // An array of stop stations for the train's route.
        public string[] StopStations { get; set; }
    }
}
