using TravelEase_WebService.TrainModels;

namespace TravelEase_WebService.Dtos.TrainService
{
    public class TrainService : ITrainService
    {
        private readonly List<Train> _trains = new List<Train>();

        public IEnumerable<Train> GetTrains()
        {
            return _trains;
        }

        public Train GetTrainById(Guid id)
        {
            return _trains.FirstOrDefault(train => train.Id == id);
        }

        public void AddTrain(Train train)
        {
            train.Id = Guid.NewGuid();
            _trains.Add(train);
        }

        public void UpdateTrain(Train train)
        {
            var existingTrain = GetTrainById(train.Id);
            if (existingTrain != null)
            {
                // Update properties as needed
                existingTrain.TrainName = train.TrainName;
                existingTrain.DepartureCity = train.DepartureCity;
                existingTrain.ArrivalCity = train.ArrivalCity;
            }
        }

        public void DeleteTrain(Guid id)
        {
            var existingTrain = GetTrainById(id);
            if (existingTrain != null)
            {
                _trains.Remove(existingTrain);
            }
        }
    }
}
