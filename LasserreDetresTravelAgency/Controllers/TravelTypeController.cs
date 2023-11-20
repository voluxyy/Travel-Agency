using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TravelTypeController : ControllerBase
    {
        private readonly ITravelTypeService service;

        public TravelTypeController(ITravelTypeService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouveau type de voyage en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données du type de voyage à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si le type de voyage est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<TravelTypeDto>> Add([FromBody] TravelTypeDto dto)
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Récupère les détails d'un type de voyage en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du type de voyage à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le type de voyage n'existe pas,
        /// les détails du type de voyage si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<TravelTypeDto>> Get(int id)
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Met à jour les détails d'un type de voyage en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant du type de voyage à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données du type de voyage.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le type de voyage n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<TravelTypeDto>> Update(int id, TravelTypeDto dto)
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Supprime un type de voyage en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du type de voyage à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le type de voyage n'existe pas,
        /// une réponse HTTP 200 OK si le type de voyage est supprimé avec succès,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpDelete("delete/{id}")]
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Obtient la liste de tous les types de voyages à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des types de voyages sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<TravelTypeDto>> GetAll()
        {
            try
            {
                return this.service.GetAll();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal Server Error");
            }
        }
    }
}