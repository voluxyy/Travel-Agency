using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface IUserService
    {
        /// <summary>
        /// Adds a new user using the provided data.
        /// </summary>
        /// <param name="dto">The user data to add.</param>
        /// <returns>Returns the added user data.</returns>
        Task<UserDto> Add(UserDto dto);
        
        /// <summary>
        /// Deletes a user based on its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>Returns the number of users deleted (0 or 1).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves user data based on its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns the user data if found, otherwise null.</returns>
        Task<UserDto> Get(int id);
        
        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>Returns a list of user data.</returns>
        List<UserDto> GetAll();
        
        /// <summary>
        /// Updates an existing user using the provided data.
        /// </summary>
        /// <param name="dto">The user data to update.</param>
        /// <returns>Returns the updated user data.</returns>
        Task<UserDto> Update(UserDto dto);
        
        /// <summary>
        /// Retrieves a list of all minor travelers.
        /// </summary>
        /// <returns>Returns a list of minor traveler data.</returns>
        List<UserDto> GetAllMinorTravelers();
    }
}