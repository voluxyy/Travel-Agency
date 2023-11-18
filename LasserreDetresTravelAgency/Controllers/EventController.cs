using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;
using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouvel événement en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données de l'événement à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si l'événement est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<EventDto>> Add([FromBody] EventDto dto)
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
        /// Récupère les détails d'un événement en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'événement à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'événement n'existe pas,
        /// les détails de l'événement si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> Get(int id)
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
        /// Met à jour les détails d'un événement en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant de l'événement à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données de l'événement.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'événement n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<EventDto>> Update(int id, EventDto dto)
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
        /// Supprime un événement en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'événement à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'événement n'existe pas,
        /// une réponse HTTP 200 OK si l'événement est supprimé avec succès,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
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
        /// Obtient la liste de tous les événements à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des événements sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<EventDto>> GetAll()
        {
            try
            {
                return this.service.GetAll();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Obtient la liste de tous les événements liés à une destination spécifique à partir du service,
        /// puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <param name="id">L'identifiant de la destination.</param>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des événements liés à la destination sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all-events-by-destination/{id}")]
        public ActionResult<List<EventDto>> GetAllEventByDest(int id)
        {
            try
            {
                return this.service.GetAllEventByDest(id);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}