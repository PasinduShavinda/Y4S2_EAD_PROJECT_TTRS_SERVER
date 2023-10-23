using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.SheduleModels;
using TravelEase_WebService.Dtos.TrainSheduleManagemet;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> GetShedules()
        {
            var sheduless = _sheduleService.GetShedules();
            return Ok(sheduless);
        }

        [HttpGet("{id}")]
        public ActionResult<Schedule> GetShedule(Guid id)
        {
            var shedule = _sheduleService.GetSheduleById(id);
            if (shedule == null)
            {
                return NotFound();
            }
            return Ok(shedule);
        }

        [HttpPost]
        public ActionResult<Schedule> CreateShedule(Schedule shedule)
        {
            _sheduleService.AddShedule(shedule);
            return CreatedAtAction(nameof(GetShedule), new { id = shedule.Id }, shedule);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShedule(Guid id, Schedule shedule)
        {
            if (id != shedule.Id)
            {
                return BadRequest();
            }
            _sheduleService.UpdateShedule(shedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrain(Guid id)
        {
            var existingSchedule = _sheduleService.GetSheduleById(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            if (existingSchedule.reserved1seates == 0 && existingSchedule.reserved2seates == 0)
            {
                _sheduleService.DeleteShedule(id);
                return NoContent();
            }
            else
            {
                return BadRequest("Cannot delete the schedule because reserved seats are not 0.");
            }
        }

        [HttpGet("GetByTrainId/{trainId}")]
        public ActionResult<IEnumerable<Schedule>> GetScheduleByTrainId(string trainId)
        {
            var matchingSchedules = _sheduleService.GetShedules().Where(schedule => schedule.TrainId == trainId).ToList();

            if (matchingSchedules.Count == 0)
            {
                return NotFound();
            }

            return Ok(matchingSchedules);
        }
        [HttpGet("FilterSchedules")]
        public ActionResult<IEnumerable<Schedule>> FilterSchedules(string date, string station1, string station2)
        {
            var filteredSchedules = _sheduleService.GetShedules()
                .Where(schedule => schedule.Date == date &&
                    schedule.StopStations.Contains(station1) &&
                    schedule.StopStations.Contains(station2))
                .ToList();

            if (filteredSchedules.Count == 0)
            {
                return NotFound();
            }

            return Ok(filteredSchedules);
        }

    }
}

