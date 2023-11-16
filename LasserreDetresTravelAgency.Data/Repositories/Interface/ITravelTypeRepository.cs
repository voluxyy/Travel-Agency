using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ITravelTypeRepository
    {
        Task<TravelType> Add(TravelType TravelType);
        Task<int> Delete(int id);
        Task<TravelType> Get(int id);
        List<TravelType> GetAll();
        Task<TravelType> Update(TravelType TravelType);
    }
}