////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: SchedulsDetails.cs
//FileType: Visual C# Source file
//Author : Kalansooriya S. H
//Description :DB model class for train sheduls
////////////////////////////////////////////////////////////////////////////////////////////////////////



namespace TravelEase_WebService.SheduleModels
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string TrainId { get; set; }
        public string TrainName { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Departuretime { get; set; }
        public string Arrivaltime { get; set; }
        public string class1reservation { get; set; }
        public string class2reservation { get; set; }
        public int reserved1seates { get; set; }
        public int reserved2seates { get; set; }
        public string[] StopStations { get; set; }
        public string Date { get; set; }

        // Add other properties as needed
    }
}
