////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ReservationService.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Reservation services for managing reservations using MongoDB
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using TravelEase_WebService.ReservationModels;

namespace TravelEase_WebService.Dtos.ReservationManagement
{
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservationCollection;

        public ReservationService()
        {
            // Initialize the MongoDB collection for reservations.
            var client = new MongoClient("mongodb+srv://it20140298:eadpw123zx@eadcluster.jwo16r4.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("eadprojectwdb");
            _reservationCollection = database.GetCollection<Reservation>("Reservations");
        }

        // Retrieve a list of all reservations.
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationCollection.Find(_ => true).ToList();
        }

        // Retrieve a reservation by its unique identifier.
        public Reservation GetReservationById(Guid id)
        {
            return _reservationCollection.Find(reservation => reservation.Id == id).FirstOrDefault();
        }

        // Add a new reservation to the system.
        public void AddReservation(Reservation reservation)
        {
            reservation.Id = Guid.NewGuid();
            _reservationCollection.InsertOne(reservation);
        }

        // Update an existing reservation with the provided data.
        public void UpdateReservation(Reservation reservation)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, reservation.Id);
            var update = Builders<Reservation>.Update
                .Set(r => r.Seatcount1, reservation.Seatcount2)
                .Set(r => r.Seatcount2, reservation.Seatcount2)
                .Set(r => r.TrainName, reservation.TrainName);

            _reservationCollection.UpdateOne(filter, update);
        }

        // Delete a reservation based on its unique identifier.
        public void DeleteReservation(Guid id)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, id);
            _reservationCollection.DeleteOne(filter);
        }

        // Retrieve a list of reservations associated with a specific user.
        public IEnumerable<Reservation> GetReservationsByUserId(string userId)
        {
            return _reservationCollection.Find(reservation => reservation.userId == userId).ToList();
        }
    }
}
