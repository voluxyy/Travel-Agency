using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository destinationRepository;
        public DestinationService(IDestinationRepository repository)
        {
            this.destinationRepository = repository;
        }

        /// <summary>
        /// Ajoute une nouvelle destination en convertissant un objet DTO en modèle, puis en l'ajoutant au référentiel.
        /// </summary>
        /// <param name="dto">L'objet DTO contenant les données de la destination à ajouter.</param>
        /// <returns>Retourne un objet DTO représentant la destination ajoutée.</returns>
        public async Task<DestinationDto> Add(DestinationDto dto)
        {
            Destination destination = DtoToModel(dto);
            await destinationRepository.Add(destination);
            DestinationDto destinationDto = ModelToDto(destination);

            return destinationDto;
        }

        /// <summary>
        /// Met à jour une destination existante en convertissant un objet DTO en modèle, puis en effectuant la mise à jour dans le référentiel.
        /// </summary>
        /// <param name="dto">L'objet DTO contenant les nouvelles données de la destination à mettre à jour.</param>
        /// <returns>Retourne un objet DTO représentant la destination mise à jour.</returns>
        public async Task<DestinationDto> Update(DestinationDto dto)
        {
            Destination destination = DtoToModel(dto);
            await destinationRepository.Update(destination);
            DestinationDto destinationDto = ModelToDto(destination);

            return destinationDto;
        }

        /// <summary>
        /// Supprime une destination en fonction de son identifiant en utilisant le référentiel.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à supprimer.</param>
        /// <returns>Retourne le nombre d'éléments supprimés (généralement 1 en cas de succès).</returns>
        public async Task<int> Delete(int id)
        {
            return await destinationRepository.Delete(id);
        }

        /// <summary>
        /// Récupère les détails d'une destination en fonction de son identifiant en utilisant le référentiel.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à récupérer.</param>
        /// <returns>Retourne un objet DTO représentant la destination récupérée.</returns>
        public async Task<DestinationDto> Get(int id)
        {
            return ModelToDto(await destinationRepository.Get(id));
        }

        /// <summary>
        /// Récupère la liste de toutes les destinations en utilisant le référentiel, puis les convertit en objets DTO de destination.
        /// </summary>
        /// <returns>Retourne une liste d'objets DTO de destination représentant toutes les destinations disponibles.</returns>
        public List<DestinationDto> GetAll()
        {
            List<Destination> destinations = destinationRepository.GetAll();
            List<DestinationDto> destinationsDtos = ListModelToDto(destinations);

            return destinationsDtos;
        }

        public List<Comment> GetComments(int id)
        {
            List<Comment> comments = destinationRepository.GetComments(id);
            return comments;
        }

        /// <summary>
        /// Convertit un objet modèle de destination en un objet DTO de destination.
        /// </summary>
        /// <param name="Destination">L'objet modèle de destination à convertir en DTO.</param>
        /// <returns>Retourne un objet DTO représentant la destination.</returns>
        private DestinationDto ModelToDto(Destination Destination)
        {
            DestinationDto DestinationDto = new DestinationDto
            {
                Id = Destination.Id,
                CountryId = Destination.CountryId,
                City = Destination.City,
                Capital = Destination.Capital,
                ToDo = Destination.ToDo.Split(", "),
                NbVisited = (Destination.Visits != null) ? Destination.Visits.Count() : 0,
                AverageRate = (Destination.Rates != null) ? Destination.Rates.Count() : 0,
                Commentaries = (Destination.Comments != null) ? ConvertCollectionToCommentDisplayed(Destination.Comments) : null,
            };

            return DestinationDto;
        }

        /// <summary>
        /// Convertit un objet DTO de destination en un objet modèle de destination.
        /// </summary>
        /// <param name="DestinationDto">L'objet DTO de destination à convertir en modèle.</param>
        /// <returns>Retourne un objet modèle de destination.</returns>
        private Destination DtoToModel(DestinationDto DestinationDto)
        {
            Destination Destination = new Destination
            {
                Id = DestinationDto.Id,
                CountryId = DestinationDto.CountryId,
                City = DestinationDto.City,
                Capital = DestinationDto.Capital,
                ToDo = ConvertTableToString(DestinationDto.ToDo),
                Visits = null,
                AverageRate = 0,
                Rates = null,
                Comments = null,
            };

            return Destination;
        }

        /// <summary>
        /// Convertit une liste d'objets modèles de destination en une liste d'objets DTO de destination.
        /// </summary>
        /// <param name="destinations">La liste des objets modèles de destination à convertir.</param>
        /// <returns>Une liste d'objets DTO de destination résultante.</returns>
        private List<DestinationDto> ListModelToDto(List<Destination> destinations)
        {
            List<DestinationDto> destinationDtos = new List<DestinationDto>();

            foreach (Destination dest in destinations)
            {
                destinationDtos.Add(ModelToDto(dest));
            }
            return destinationDtos;
        }

        private string ConvertTableToString(string[] destination)
        {
            string result = "";

            for(int i = 0; i < destination.Length; i++)
            {
                if (i == destination.Length-1)
                {
                    result += destination[i];
                    break;
                }
                result += destination[i] + ", ";
            }

            return result;
        }

        private string[] ConvertCollectionToStringTable(ICollection<Comment> comments)
        {
            string[] strings = new string[0];

            List<Comment> listComments = comments.AsEnumerable().ToList();
            for (int i = 0; i < listComments.Count; i++)
            {
                strings[i] = listComments.ElementAt(i).Text;
            }

            return strings;
        }

        private CommentDisplayed[] ConvertCollectionToCommentDisplayed(ICollection<Comment> comments)
        {
            foreach (var item in comments.ToList())
            {
                User user;
                // TODO: Implement a new Repository for each tables in the database (Particular for User).
            }
            CommentDisplayed[] commentDisplayeds = null;
            return commentDisplayeds;
        }
    }
}
