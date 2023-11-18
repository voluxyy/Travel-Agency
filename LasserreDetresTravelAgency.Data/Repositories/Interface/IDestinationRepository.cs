using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public interface IDestinationRepository
    {
        
        /// <summary>
        /// Ajoute une destination à la base de données en utilisant l'objet modèle passé en paramètre.
        /// </summary>
        /// <param name="destinations">L'objet modèle de destination à ajouter à la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination qui a été ajouté à la base de données.</returns>
        Task<Destination> Add(Destination destination);
        
        /// <summary>
        /// Supprime une destination de la base de données en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à supprimer de la base de données.</param>
        /// <returns>Retourne le nombre de modifications effectuées dans la base de données (généralement 1 en cas de succès).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Récupère une destination de la base de données en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à récupérer depuis la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination récupéré depuis la base de données.</returns>
        Task<Destination> Get(int id);
        
        /// <summary>
        /// Récupère la liste de toutes les destinations depuis la base de données.
        /// </summary>
        /// <returns>Retourne une liste d'objets modèle de destination représentant toutes les destinations disponibles dans la base de données.</returns>
        List<Destination> GetAll();
        
        /// <summary>
        /// Met à jour une destination existante dans la base de données en utilisant l'objet modèle passé en paramètre.
        /// </summary>
        /// <param name="destinations">L'objet modèle de destination à mettre à jour dans la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination qui a été mis à jour dans la base de données.</returns>
        Task<Destination> Update(Destination destination);
    }
}