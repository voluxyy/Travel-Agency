using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IRateService
    {
        
        /// <summary>
        /// Adds a new rate using the provided data.
        /// </summary>
        /// <param name="dto">The rate data to add.</param>
        /// <returns>Returns the added rate data.</returns>
        Task<RateDto> Add(RateDto dto);
        
        /// <summary>
        /// Deletes a rate based on its ID.
        /// </summary>
        /// <param name="id">The ID of the rate to delete.</param>
        /// <returns>Returns the number of rates deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves rate data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the rate to retrieve.</param>
        /// <returns>Returns the rate data if found, otherwise null.</returns>
        Task<RateDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all rates.
        /// </summary>
        /// <returns>Returns a list of rate data.</returns>
        List<RateDto> GetAll();
        
        /// <summary>
        /// Updates an existing rate using the provided data.
        /// </summary>
        /// <param name="dto">The rate data to update.</param>
        /// <returns>Returns the updated rate data.</returns>
        Task<RateDto> Update(RateDto dto);
    }
}