using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ITravelsRepository
    {
        Task<Travels> Add(Travels travels);
        Task<int> Delete(int id);
        Task<Travels> Get(int id);
        List<Travels> GetAll();
        List<Travels> GetAllFutureTravels();
        List<Travels> GetAllPasteTravels();
        Task<Travels> Update(Travels travels);
    }
}