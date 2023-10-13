////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: IReservationService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Reservation service interface defining methods for reservation management
////////////////////////////////////////////////////////////////////////////////////////////////////////

using TravelEase_WebService.ReservationModels;

namespace TravelEase_WebService.Dtos.ReservationManagement
{
    // This interface defines the contract for managing reservations.
    public interface IReservationService
    {
        // Retrieves a list of all reservations.
        IEnumerable<Reservation> GetReservations();

        // Retrieves a reservation by its unique identifier.
        Reservation GetReservationById(Guid id);

        // Adds a new reservation to the system.
        void AddReservation(Reservation reservation);

        // Updates an existing reservation with the provided data.
        void UpdateReservation(Reservation reservation);

        // Deletes a reservation based on its unique identifier.
        void DeleteReservation(Guid id);

        // Retrieves a list of reservations associated with a specific user.
        IEnumerable<Reservation> GetReservationsByUserId(string userId);
    }
}
