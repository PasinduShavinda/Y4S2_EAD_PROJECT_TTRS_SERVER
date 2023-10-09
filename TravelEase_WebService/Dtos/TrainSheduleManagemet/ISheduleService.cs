
using TravelEase_WebService.SheduleModels;
namespace TravelEase_WebService.Dtos.TrainSheduleManagemet;


public interface IScheduleService
{
    IEnumerable<Schedule> GetShedules();
    Schedule GetSheduleById(Guid id);
    void AddShedule(Schedule shedule);
    void UpdateShedule(Schedule shedule);
    void DeleteShedule(Guid id);
    IEnumerable<Schedule> GetSchedulesByTrainId(string trainId);
}

