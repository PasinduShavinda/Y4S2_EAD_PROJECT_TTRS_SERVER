////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ReservationController.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Controller for managing reservations
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.ReservationModels;
using TravelEase_WebService.Dtos.ReservationManagement;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TravelEase_WebService.Controllers.ReservationManagement
{
    //[Authorize(Roles = "Travel Agent,Traveller")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservation
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetReservations()
        {
            // Retrieve a list of reservations from the service.
            var reservations = _reservationService.GetReservations();
            return Ok(reservations);
        }

        // GET: api/Reservation/{id}
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(Guid id)
        {
            // Retrieve a reservation by its unique identifier.
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound(); // Return a 404 Not Found response if the reservation is not found.
            }
            return Ok(reservation);
        }

        // POST: api/Reservation
        [HttpPost]
        public ActionResult<Reservation> CreateReservation(Reservation reservation)
        {
            // Create a new reservation by calling the service.
            _reservationService.AddReservation(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        // PUT: api/Reservation/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReservation(Guid id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest(); // Return a Bad Request response if the ID in the URL doesn't match the ID in the request.
            }
            _reservationService.UpdateReservation(reservation);
            return NoContent(); // Return a 204 No Content response after successfully updating the reservation.
        }

        // DELETE: api/Reservation/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(Guid id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound(); // Return a 404 Not Found response if the reservation is not found.
            }
            _reservationService.DeleteReservation(id);
            return NoContent(); // Return a 204 No Content response after successfully deleting the reservation.
        }

        // GET: api/Reservation/byUserId/{userId}
        [HttpGet("byUserId/{userId}")]
        public ActionResult<IEnumerable<Reservation>> GetReservationsByUserId(string userId)
        {
            // Retrieve a list of reservations associated with a specific user.
            var reservations = _reservationService.GetReservationsByUserId(userId);
            return Ok(reservations);
        }
    }
}
