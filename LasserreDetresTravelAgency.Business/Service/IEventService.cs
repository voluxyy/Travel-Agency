using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IEventService
    {
        Task<EventDto> Add(EventDto dto);
        Task<int> Delete(int id);
        Task<EventDto> Get(int id);
        List<EventDto> GetAll();
        Task<EventDto> Update(EventDto dto);
        List<EventDto> GetAllEventByDest(int id);
    }
}