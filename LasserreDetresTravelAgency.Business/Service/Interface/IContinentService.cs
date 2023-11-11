using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IContinentService
    {
        Task<ContinentDto> Add(ContinentDto dto);
        Task<int> Delete(int id);
        Task<ContinentDto> Get(int id);
        List<ContinentDto> GetAll();
        Task<ContinentDto> Update(ContinentDto dto);
    }
}