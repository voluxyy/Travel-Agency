using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICountryService
    {
        /// <summary>
        /// Adds a new country using the provided data.
        /// </summary>
        /// <param name="dto">The country data to add.</param>
        /// <returns>Returns the added country data.</returns>
        Task<CountryDto> Add(CountryDto dto);
        
        /// <summary>
        /// Deletes a country based on its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>Returns the number of countries deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves country data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>Returns the country data if found, otherwise null.</returns>
        Task<CountryDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>Returns a list of country data.</returns>
        List<CountryDto> GetAll();
        
        /// <summary>
        /// Updates an existing country using the provided data.
        /// </summary>
        /// <param name="dto">The country data to update.</param>
        /// <returns>Returns the updated country data.</returns>
        Task<CountryDto> Update(CountryDto dto);
    }
}