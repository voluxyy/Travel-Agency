using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IDestinationService
    {
        
        /// <summary>
        /// Adds a new destination using the provided data.
        /// </summary>
        /// <param name="dto">The destination data to add.</param>
        /// <returns>Returns the added destination data.</returns>
        Task<DestinationDto> Add(DestinationDto dto);
        
        /// <summary>
        /// Deletes a destination based on its ID.
        /// </summary>
        /// <param name="id">The ID of the destination to delete.</param>
        /// <returns>Returns the number of destinations deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves destination data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the destination to retrieve.</param>
        /// <returns>Returns the destination data if found, otherwise null.</returns>
        Task<DestinationDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all destinations.
        /// </summary>
        /// <returns>Returns a list of destination data.</returns>
        List<DestinationDto> GetAll();
        
        /// <summary>
        /// Updates an existing destination using the provided data.
        /// </summary>
        /// <param name="dto">The destination data to update.</param>
        /// <returns>Returns the updated destination data.</returns>
        Task<DestinationDto> Update(DestinationDto dto);
        
        /// <summary>
        /// Retrieves a list of destinations that have been visited.
        /// </summary>
        /// <returns>Returns a list of visited destination data.</returns>
        List<DestinationDto> GetAllVisited();

        List<DestinationDto> GetAllDestinationByUserAndCategory(int userId, int CategoryId);
    }
}