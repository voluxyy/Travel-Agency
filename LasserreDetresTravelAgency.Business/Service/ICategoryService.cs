using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICategoryService
    {
        Task<CategoryDto> Add(CategoryDto dto);
    }
}