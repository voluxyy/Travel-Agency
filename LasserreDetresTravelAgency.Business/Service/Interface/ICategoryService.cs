using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Business.Service
{
    public interface ICategoryService
    {
        /// <summary>
        /// Ajoute une nouvelle catégorie.
        /// </summary>
        /// <param name="dto">Les données de la catégorie à ajouter.</param>
        /// <returns>Retourne les données de la catégorie ajoutée.</returns>
        Task<CategoryDto> Add(CategoryDto dto);

        /// <summary>
        /// Supprime une catégorie en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie à supprimer.</param>
        /// <returns>Retourne le nombre d'enregistrements supprimés (généralement 1 si la catégorie existait).</returns>
        Task<int> Delete(int id);
        
        /// <summary>
        /// Récupère une catégorie en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie à récupérer.</param>
        /// <returns>Retourne les données de la catégorie récupérée.</returns>
        Task<CategoryDto> Get(int id);

        /// <summary>
        /// Met à jour une catégorie existante.
        /// </summary>
        /// <param name="dto">Les nouvelles données de la catégorie à mettre à jour.</param>
        /// <returns>Retourne les données de la catégorie mise à jour.</returns>
        Task<CategoryDto> Update(CategoryDto dto);
        
        /// <summary>
        /// Récupère toutes les catégories.
        /// </summary>
        /// <returns>Retourne une liste de toutes les catégories.</returns>
        List<CategoryDto> GetAll();
    }
}