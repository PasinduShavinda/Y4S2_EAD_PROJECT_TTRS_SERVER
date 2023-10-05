// Controllers/TrainController.cs
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.TrainModels;
using TravelEase_WebService.Services;

namespace TravelEase_WebService.TrainController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Train>> GetTrains()
        {
            var trains = _trainService.GetTrains();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public ActionResult<Train> GetTrain(Guid id)
        {
            var train = _trainService.GetTrainById(id);
            if (train == null)
            {
                return NotFound();
            }
            return Ok(train);
        }

        [HttpPost]
        public ActionResult<Train> CreateTrain(Train train)
        {
            _trainService.AddTrain(train);
            return CreatedAtAction(nameof(GetTrain), new { id = train.Id }, train);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrain(Guid id, Train train)
        {
            if (id != train.Id)
            {
                return BadRequest();
            }
            _trainService.UpdateTrain(train);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrain(Guid id)
        {
            var existingTrain = _trainService.GetTrainById(id);
            if (existingTrain == null)
            {
                return NotFound();
            }
            _trainService.DeleteTrain(id);
            return NoContent();
        }
    }
}
