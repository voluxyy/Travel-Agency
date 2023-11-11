using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICategoryService
    {
        Task<CategoryDto> Add(CategoryDto dto);
        Task<int> Delete(int id);
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Update(CategoryDto dto);
        List<CategoryDto> GetAll();
    }
}