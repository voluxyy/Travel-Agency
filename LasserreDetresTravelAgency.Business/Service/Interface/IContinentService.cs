using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IContinentService
    {
        /// <summary>
        /// Adds a new continent using the provided data.
        /// </summary>
        /// <param name="dto">The continent data to add.</param>
        /// <returns>Returns the added continent data.</returns>
        Task<ContinentDto> Add(ContinentDto dto);
        
        /// <summary>
        /// Deletes a continent based on its ID.
        /// </summary>
        /// <param name="id">The ID of the continent to delete.</param>
        /// <returns>Returns the number of continents deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves continent data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the continent to retrieve.</param>
        /// <returns>Returns the continent data if found, otherwise null.</returns>
        Task<ContinentDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all continents.
        /// </summary>
        /// <returns>Returns a list of continent data.</returns>
        List<ContinentDto> GetAll();
        
        /// <summary>
        /// Updates an existing continent using the provided data.
        /// </summary>
        /// <param name="dto">The continent data to update.</param>
        /// <returns>Returns the updated continent data.</returns>
        Task<ContinentDto> Update(ContinentDto dto);
    }
}