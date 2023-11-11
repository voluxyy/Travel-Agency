using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IFavoryService
    {
        Task<FavoryDto> Add(FavoryDto dto);
        Task<int> Delete(int id);
        Task<FavoryDto> Get(int id);
        List<FavoryDto> GetAll();
        Task<FavoryDto> Update(FavoryDto dto);
    }
}