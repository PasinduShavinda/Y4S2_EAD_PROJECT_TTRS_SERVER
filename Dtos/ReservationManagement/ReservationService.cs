

using TravelEase_WebService.ReservationModels;

namespace TravelEase_WebService.Dtos.ReservationManagement;

public class ReservationService : IReservationService
{
    private readonly List<Reservation> _reservation = new List<Reservation>();

    public IEnumerable<Reservation> GetReservations()
    {
        return _reservation;
    }

    public Reservation GetReservationById(Guid id)
    {
        return _reservation.FirstOrDefault(reservation => reservation.Id == id);
    }

    public void AddReservation(Reservation reservation)
    {
        reservation.Id = Guid.NewGuid();
        _reservation.Add(reservation);
    }

    public void UpdateReservation(Reservation reservation)
    {
        var existingReservation = GetReservationById(reservation.Id);
        if (existingReservation != null)
        {
            // Update properties as needed
            existingReservation.SeatNumber = reservation.SeatNumber;
            existingReservation.Class = reservation.Class;
            existingReservation.Train = reservation.Train;
        }
    }

    public void DeleteReservation(Guid id)
    {
        var existingTrain = GetReservationById(id);
        if (existingTrain != null)
        {
            _reservation.Remove(existingTrain);
        }
    }
}
