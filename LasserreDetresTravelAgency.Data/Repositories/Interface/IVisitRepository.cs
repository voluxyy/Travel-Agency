using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IVisitRepository
    {
        Task<Visit> Add(Visit visit);
        Task<int> Delete(int id);
        Task<Visit> Get(int id);
        List<Visit> GetAll();
        Task<Visit> Update(Visit visit);
        List<Visit> GetAllVisited();
    }
}