using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IUserService
    {
        Task<UserDto> Add(UserDto dto);
        Task<int> Delete(int id);
        Task<UserDto> Get(int id);
        List<UserDto> GetAll();
        Task<UserDto> Update(UserDto dto);
        List<UserDto> GetAllMinorTravelers(UserDto user);
    }
}