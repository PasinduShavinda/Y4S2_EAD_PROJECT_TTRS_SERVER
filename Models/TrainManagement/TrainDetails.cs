// Models/TrainsDetails.cs
// Models/Train.cs
using System;

namespace TravelEase_WebService.TrainModels
{
    public class Train
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        // Add other properties as needed
    }
}
