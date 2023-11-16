using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ITravelTypeService
    {
        Task<TravelTypeDto> Add(TravelTypeDto dto);
        Task<int> Delete(int id);
        Task<TravelTypeDto> Get(int id);
        Task<TravelTypeDto> Update(TravelTypeDto dto);
        List<TravelTypeDto> GetAll();
    }
}