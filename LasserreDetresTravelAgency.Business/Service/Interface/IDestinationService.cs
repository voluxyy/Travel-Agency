using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IDestinationService
    {
        Task<DestinationDto> Add(DestinationDto dto);
        Task<int> Delete(int id);
        Task<DestinationDto> Get(int id);
        List<DestinationDto> GetAll();
        Task<DestinationDto> Update(DestinationDto dto);
        List<DestinationDto> GetAllVisited();
    }
}