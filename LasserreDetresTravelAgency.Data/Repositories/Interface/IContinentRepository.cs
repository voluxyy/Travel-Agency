using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IContinentRepository
    {
        Task<Continent> Add(Continent Continent);
        Task<int> Delete(int id);
        Task<Continent> Get(int id);
        List<Continent> GetAll();
        Task<Continent> Update(Continent Continent);
    }
}