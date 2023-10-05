
using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.ReservationModels;
using TravelEase_WebService.Dtos.ReservationManagement;

namespace TravelEase_WebService.Controllers.ReservationManagement;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Reservation>> GetReservations()
    {
        var reservations = _reservationService.GetReservations();
        return Ok(reservations);
    }

    [HttpGet("{id}")]
    public ActionResult<Reservation> GetReservation(Guid id)
    {
        var reservation = _reservationService.GetReservationById(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    [HttpPost]
    public ActionResult<Reservation> CreateReservation(Reservation reservation)
    {
        _reservationService.AddReservation(reservation);
        return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReservation(Guid id, Reservation reservation)
    {
        if (id != reservation.Id)
        {
            return BadRequest();
        }
        _reservationService.UpdateReservation(reservation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReservation(Guid id)
    {
        var reservation = _reservationService.GetReservationById(id);
        if (reservation == null)
        {
            return NotFound();
        }
        _reservationService.DeleteReservation(id);
        return NoContent();
    }
}