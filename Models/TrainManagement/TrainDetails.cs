

namespace TravelEase_WebService.TrainModels
{
    public class Train
    {
        public Guid Id { get; set; }
        public string TrainName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Departuretime { get; set; }
        public string Arrivaltime { get; set; }
        public string class1reservation { get; set; }
        public string class2reservation { get; set; }
        public string[] StopStations { get; set; }


        // Add other properties as needed
    }
}
