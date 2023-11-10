using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IEventRepository
    {
        Task<Event> Add(Event evenement);
        Task<int> Delete(int id);
        Task<Event> Get(int id);
        List<Event> GetAll();
        Task<Event> Update(Event evenement);
    }
}