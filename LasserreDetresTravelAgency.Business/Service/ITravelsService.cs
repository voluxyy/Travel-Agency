using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ITravelsService
    {
        Task<TravelsDto> Add(TravelsDto dto);
        Task<int> Delete(int id);
        Task<TravelsDto> Get(int id);
        List<TravelsDto> GetAll();
        Task<TravelsDto> Update(TravelsDto dto);
    }
}