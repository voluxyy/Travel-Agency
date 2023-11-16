using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IVisitService
    {
        
        /// <summary>
        /// Adds a new visit using the provided data.
        /// </summary>
        /// <param name="dto">The visit data to add.</param>
        /// <returns>Returns the added visit data.</returns>
        Task<VisitDto> Add(VisitDto dto);
        
        /// <summary>
        /// Deletes a visit based on its ID.
        /// </summary>
        /// <param name="id">The ID of the visit to delete.</param>
        /// <returns>Returns the number of visits deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves visit data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the visit to retrieve.</param>
        /// <returns>Returns the visit data if found, otherwise null.</returns>
        Task<VisitDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all visits.
        /// </summary>
        /// <returns>Returns a list of visit data.</returns>
        List<VisitDto> GetAll();
        
        /// <summary>
        /// Updates an existing visit using the provided data.
        /// </summary>
        /// <param name="dto">The visit data to update.</param>
        /// <returns>Returns the updated visit data.</returns>
        Task<VisitDto> Update(VisitDto dto);
    }
}