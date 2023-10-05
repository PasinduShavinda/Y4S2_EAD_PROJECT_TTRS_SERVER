
using TravelEase_WebService.TrainModels;
namespace TravelEase_WebService.Dtos.TrainService;


public interface ITrainService
{
    IEnumerable<Train> GetTrains();
    Train GetTrainById(Guid id);
    void AddTrain(Train train);
    void UpdateTrain(Train train);
    void DeleteTrain(Guid id);
}

