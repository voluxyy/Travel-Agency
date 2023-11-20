using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelsService service;

        public TravelsController(ITravelsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouveau voyage en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données du voyage à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si le voyage est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<TravelsDto>> Add([FromBody] TravelsDto dto)
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
        /// Récupère les détails d'un voyage en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du voyage à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le voyage n'existe pas,
        /// les détails du voyage si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<TravelsDto>> Get(int id)
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
        /// Met à jour les détails d'un voyage en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant du voyage à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données du voyage.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le voyage n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<TravelsDto>> Update(int id, TravelsDto dto)
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
        /// Supprime un voyage en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du voyage à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le voyage n'existe pas,
        /// une réponse HTTP 200 OK si le voyage est supprimé avec succès,
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
        /// Obtient la liste de tous les voyages à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des voyages sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<TravelsDto>> GetAll()
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

        /// <summary>
        /// Obtient la liste de tous les voyages futurs à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des voyages futurs sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all-future-date")]
        public ActionResult<List<TravelsDto>> GetAllFutureTravels()
        {
            try
            {
                return this.service.GetAllFutureTravels();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Obtient la liste de tous les voyages passés à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des voyages passés sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all-paste-date")]
        public ActionResult<List<TravelsDto>> GetAllPastTravels()
        {
            try
            {
                return this.service.GetAllPastTravels();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal Server Error");
            }
        }
    }
}