using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICountryService
    {
        Task<CountryDto> Add(CountryDto dto);
        Task<int> Delete(int id);
        Task<CountryDto> Get(int id);
        List<CountryDto> GetAll();
        Task<CountryDto> Update(CountryDto dto);
    }
}