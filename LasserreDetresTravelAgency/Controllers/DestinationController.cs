using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
using LasserreDetresTravelAgency.Data.Models;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService service;
        
        public DestinationController(IDestinationService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute une nouvelle destination en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données de la destination à ajouter.</param>
        /// <returns>Retourne une réponse HTTP 201 Created si la destination est ajoutée avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation, ou une réponse HTTP 500
        /// Internal Server Error en cas d'erreur interne du serveur.</returns>
        [HttpPost]
        public async Task<ActionResult<DestinationDto>> Add([FromBody] DestinationDto dto)
        {
            try
            {
                await this.service.Add(dto);
                return StatusCode(StatusCodes.Status201Created, dto);
            }
            catch (ArgumentNullException)
            {
                return this.ValidationProblem();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Récupère les détails d'une destination en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à récupérer.</param>
        /// <returns>Retourne une réponse HTTP 404 NotFound si la destination n'existe pas,
        /// les détails de la destination si elle est trouvée, ou une réponse HTTP 500
        /// Internal Server Error en cas d'erreur interne du serveur.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinationDto>> Get(int id)
        {
            if (id <= default(int))
            {
                return NotFound();
            }

            try
            {
                return await this.service.Get(id);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Met à jour les détails d'une destination en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données de la destination.</param>
        /// <returns>Retourne une réponse HTTP 404 NotFound si la destination n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation, ou une réponse HTTP 500
        /// Internal Server Error en cas d'erreur interne du serveur.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<DestinationDto>> Update(int id, DestinationDto dto)
        {
            if (id <= default(int))
            {
                return NotFound();
            }

            try
            {
                return await this.service.Update(dto);
            }
            catch (ArgumentNullException)
            {
                return this.ValidationProblem();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Supprime une destination en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la destination à supprimer.</param>
        /// <returns>Retourne une réponse HTTP 404 NotFound si la destination n'existe pas,
        /// une réponse HTTP 200 OK si la destination est supprimée avec succès, ou une réponse HTTP 500
        /// Internal Server Error en cas d'erreur interne du serveur.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= default(int))
            {
                return NotFound();
            }

            try
            {
                await this.service.Delete(id);
                return this.Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Obtient la liste de toutes les destinations à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>Retourne une réponse HTTP contenant la liste des destinations sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.</returns>
        [HttpGet("all")]
        public ActionResult<List<DestinationDto>> GetAll()
        {
            try
            {
                Console.WriteLine("GetAll");
                return this.service.GetAll();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}
