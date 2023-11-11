using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IRateService
    {
        Task<RateDto> Add(RateDto dto);
        Task<int> Delete(int id);
        Task<RateDto> Get(int id);
        List<RateDto> GetAll();
        Task<RateDto> Update(RateDto dto);
    }
}