////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ReservationDetails.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: DB model class for reservations
////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TravelEase_WebService.ReservationModels
{
    // This class represents a reservation in the database.
    public class Reservation
    {
        // Unique identifier for the reservation.
        public Guid Id { get; set; }

        // The number of seats in category 1 for this reservation.
        public int Seatcount1 { get; set; }

        // The number of seats in category 2 for this reservation.
        public int Seatcount2 { get; set; }

        // The name of the train associated with this reservation.
        public string TrainName { get; set; }

        // The unique identifier for the train.
        public string TrainId { get; set; }

        // The user's identifier who made the reservation.
        public string userId { get; set; }

        // The schedule identifier for the train.
        public string SheduleId { get; set; }

        // The date of the reservation.
        public string date { get; set; }
    }
}
