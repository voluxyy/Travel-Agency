using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IRateRepository
    {
        Task<Rate> Add(Rate rate);
        Task<int> Delete(int id);
        Task<Rate> Get(int id);
        List<Rate> GetAll();
        Task<Rate> Update(Rate rate);
    }
}