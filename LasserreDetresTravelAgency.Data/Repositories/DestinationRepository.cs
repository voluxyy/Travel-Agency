using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext _context;

        public DestinationRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Ajoute une destination à la base de données en utilisant l'objet modèle passé en paramètre.
        /// </summary>
        /// <param name="destinations">L'objet modèle de destination à ajouter à la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination qui a été ajouté à la base de données.</returns>
        public async Task<Destination> Add(Destination destination)
        {
            _context.Destinations.Add(destination);

            await _context.SaveChangesAsync();

            return destination;
        }

        /// <summary>
        /// Met à jour une destination existante dans la base de données en utilisant l'objet modèle passé en paramètre.
        /// </summary>
        /// <param name="destinations">L'objet modèle de destination à mettre à jour dans la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination qui a été mis à jour dans la base de données.</returns>
        public async Task<Destination> Update(Destination destination)
        {
            _context.Destinations.Update(destination);

            await _context.SaveChangesAsync();

            return destination;
        }

        /// <summary>
        /// Supprime une destination de la base de données en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à supprimer de la base de données.</param>
        /// <returns>Retourne le nombre de modifications effectuées dans la base de données (généralement 1 en cas de succès).</returns>
        public async Task<int> Delete(int id)
        {
            Destination destination = await _context.Destinations.FindAsync(id);

            _context.Destinations.Remove(destination);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Récupère une destination de la base de données en utilisant son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à récupérer depuis la base de données.</param>
        /// <returns>Retourne l'objet modèle de destination récupéré depuis la base de données.</returns>
        public async Task<Destination> Get(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        /// <summary>
        /// Récupère la liste de toutes les destinations depuis la base de données.
        /// </summary>
        /// <returns>Retourne une liste d'objets modèle de destination représentant toutes les destinations disponibles dans la base de données.</returns>
        public List<Destination> GetAll()
        {
            return _context.Destinations.ToList();
        }
    }
}
