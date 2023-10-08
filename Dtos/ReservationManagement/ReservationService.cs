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
            var client = new MongoClient("mongodb+srv://sugandhi:EP7ZKYIQ43cBQVDV@cluster0.amprpac.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("eadprojectwdb");
            _reservationCollection = database.GetCollection<Reservation>("Reservations"); 
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationCollection.Find(_ => true).ToList();
        }

        public Reservation GetReservationById(Guid id)
        {
            return _reservationCollection.Find(reservation => reservation.Id == id).FirstOrDefault();
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.Id = Guid.NewGuid();
            _reservationCollection.InsertOne(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, reservation.Id);
            var update = Builders<Reservation>.Update
                .Set(r => r.SeatNumber, reservation.SeatNumber)
                .Set(r => r.Class, reservation.Class)
                .Set(r => r.Train, reservation.Train);

            _reservationCollection.UpdateOne(filter, update);
        }

        public void DeleteReservation(Guid id)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, id);
            _reservationCollection.DeleteOne(filter);
        }
    }
}
