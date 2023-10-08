

namespace TravelEase_WebService.ReservationModels
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public int Seatcount1 { get; set; }
        public int Seatcount2 { get; set; }
        public string TrainName { get; set; }
        public string TrainId { get; set; }
        public string userId { get; set; }
        public string SheduleId { get; set; }
        public string date { get; set; }
    }
}
