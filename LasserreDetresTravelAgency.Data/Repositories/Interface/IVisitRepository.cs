using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IVisitRepository
    {
        
        /// <summary>
        /// Adds a visit record to the database using the provided visit model object.
        /// </summary>
        /// <param name="visit">The visit model object to add to the database.</param>
        /// <returns>Returns the visit model object that has been added to the database.</returns>
        Task<Visit> Add(Visit visit);
        
        /// <summary>
        /// Deletes a visit record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the visit record to delete from the database.</param>
        /// <returns>Returns the number of changes made in the database (usually 1 on success).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Retrieves a visit record from the database using its identifier.
        /// </summary>
        /// <param name="id">The identifier of the visit record to retrieve from the database.</param>
        /// <returns>Returns the visit model object retrieved from the database.</returns>
        Task<Visit> Get(int id);
        
        /// <summary>
        /// Retrieves the list of all visit records from the database.
        /// </summary>
        /// <returns>Returns a list of visit model objects representing all available visit records in the database.</returns>
        List<Visit> GetAll();
        
        /// <summary>
        /// Updates an existing visit record in the database using the provided visit model object.
        /// </summary>
        /// <param name="visit">The visit model object to update in the database.</param>
        /// <returns>Returns the visit model object that has been updated in the database.</returns>
        Task<Visit> Update(Visit visit);
        
        /// <summary>
        /// Retrieves the list of all visited visit records from the database.
        /// </summary>
        /// <returns>Returns a list of visit model objects representing all visited visit records in the database.</returns>
        List<Visit> GetAllVisited();
    }
}