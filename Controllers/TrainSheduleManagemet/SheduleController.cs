////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: ScheduleController.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Controller for managing train schedules
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.SheduleModels;
using TravelEase_WebService.Dtos.TrainSheduleManagemet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelEase_WebService.SheduleController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _sheduleService;

        public ScheduleController(IScheduleService sheduleService)
        {
            _sheduleService = sheduleService;
        }

        // GET: api/Schedule
        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetShedules()
        {
            // Retrieve a list of schedules from the service.
            var sheduless = _sheduleService.GetShedules();
            return Ok(sheduless);
        }

        // GET: api/Schedule/{id}
        [HttpGet("{id}")]
        public ActionResult<Schedule> GetShedule(Guid id)
        {
            // Retrieve a schedule by its unique identifier.
            var shedule = _sheduleService.GetSheduleById(id);
            if (shedule == null)
            {
                return NotFound(); // Return a 404 Not Found response if the schedule is not found.
            }
            return Ok(shedule);
        }

        // POST: api/Schedule
        [HttpPost]
        public ActionResult<Schedule> CreateShedule(Schedule shedule)
        {
            // Create a new schedule by calling the service.
            _sheduleService.AddShedule(shedule);
            return CreatedAtAction(nameof(GetShedule), new { id = shedule.Id }, shedule);
        }

        // PUT: api/Schedule/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateShedule(Guid id, Schedule shedule)
        {
            if (id != shedule.Id)
            {
                return BadRequest(); // Return a Bad Request response if the ID in the URL doesn't match the ID in the request.
            }
            _sheduleService.UpdateShedule(shedule);
            return NoContent(); // Return a 204 No Content response after successfully updating the schedule.
        }

        // DELETE: api/Schedule/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTrain(Guid id)
        {
            var existingshedule = _sheduleService.GetSheduleById(id);
            if (existingshedule == null)
            {
                return NotFound(); // Return a 404 Not Found response if the schedule is not found.
            }
            _sheduleService.DeleteShedule(id);
            return NoContent(); // Return a 204 No Content response after successfully deleting the schedule.
        }

        // GET: api/Schedule/GetByTrainId/{trainId}
        [HttpGet("GetByTrainId/{trainId}")]
        public ActionResult<IEnumerable<Schedule>> GetScheduleByTrainId(string trainId)
        {
            // Retrieve a list of schedules associated with a specific train.
            var matchingSchedules = _sheduleService.GetShedules().Where(schedule => schedule.TrainId == trainId).ToList();

            if (matchingSchedules.Count == 0)
            {
                return NotFound();
            }

            return Ok(matchingSchedules);
        }

        // GET: api/Schedule/FilterSchedules
        [HttpGet("FilterSchedules")]


