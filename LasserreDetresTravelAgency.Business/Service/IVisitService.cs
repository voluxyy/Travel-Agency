using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IVisitService
    {
        Task<VisitDto> Add(VisitDto dto);
        Task<int> Delete(int id);
        Task<VisitDto> Get(int id);
        List<VisitDto> GetAll();
        Task<VisitDto> Update(VisitDto dto);
    }
}