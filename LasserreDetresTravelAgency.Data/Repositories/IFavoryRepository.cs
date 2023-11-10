using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IFavoryRepository
    {
        Task<Favory> Add(Favory favory);
        Task<int> Delete(int id);
        Task<Favory> Get(int id);
        List<Favory> GetAll();
        Task<Favory> Update(Favory favory);
    }
}