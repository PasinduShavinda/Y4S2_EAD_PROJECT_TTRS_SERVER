

using TravelEase_WebService.ReservationModels;

namespace TravelEase_WebService.Dtos.ReservationManagement
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetReservations();
        Reservation GetReservationById(Guid id);
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Guid id);
        IEnumerable<Reservation> GetReservationsByUserId(string userId);
    }
}
