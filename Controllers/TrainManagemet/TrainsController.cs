////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: TrainController.cs
// FileType: Visual C# Source file
// Author: Kalansooriya S. H
// Description: Controller for managing train details
////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using TravelEase_WebService.TrainModels;
using TravelEase_WebService.Dtos.TrainService;

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

        // GET: api/Train
        [HttpGet]
        public ActionResult<IEnumerable<Train>> GetTrains()
        {
            // Retrieve a list of trains from the service.
            var trains = _trainService.GetTrains();
            return Ok(trains);
        }

        // GET: api/Train/{id}
        [HttpGet("{id}")]
        public ActionResult<Train> GetTrain(Guid id)
        {
            // Retrieve a train by its unique identifier.
            var train = _trainService.GetTrainById(id);
            if (train == null)
            {
                return NotFound(); // Return a 404 Not Found response if the train is not found.
            }
            return Ok(train);
        }

        // POST: api/Train
        [HttpPost]
        public ActionResult<Train> CreateTrain(Train train)
        {
            // Create a new train by calling the service.
            _trainService.AddTrain(train);
            return CreatedAtAction(nameof(GetTrain), new { id = train.Id }, train);
        }

        // PUT: api/Train/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTrain(Guid id, Train train)
        {
            if (id != train.Id)
            {
                return BadRequest(); // Return a Bad Request response if the ID in the URL doesn't match the ID in the request.
            }
            _trainService.UpdateTrain(train);
            return NoContent(); // Return a 204 No Content response after successfully updating the train.
        }

        // DELETE: api/Train/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTrain(Guid id)
        {
            var existingTrain = _trainService.GetTrainById(id);
            if (existingTrain == null)
            {
                return NotFound(); // Return a 404 Not Found response if the train is not found.
            }
            _trainService.DeleteTrain(id);
            return NoContent(); // Return a 204 No Content response after successfully deleting the train.
        }
    }
}
