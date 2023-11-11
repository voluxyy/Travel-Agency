using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> Add(Country country);
        Task<int> Delete(int id);
        Task<Country> Get(int id);
        List<Country> GetAll();
        Task<Country> Update(Country country);
    }
}