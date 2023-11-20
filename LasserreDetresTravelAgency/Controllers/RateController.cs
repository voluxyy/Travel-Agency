using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService service;
        
        public RateController(IRateService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute une nouvelle évaluation en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données de l'évaluation à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si l'évaluation est ajoutée avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<RateDto>> Add([FromBody] RateDto dto)
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
        /// Récupère les détails d'une évaluation en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'évaluation à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'évaluation n'existe pas,
        /// les détails de l'évaluation si elle est trouvée,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<RateDto>> Get(int id)
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
        /// Met à jour les détails d'une évaluation en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant de l'évaluation à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données de l'évaluation.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'évaluation n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<RateDto>> Update(int id, RateDto dto)
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
        /// Supprime une évaluation en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'évaluation à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'évaluation n'existe pas,
        /// une réponse HTTP 200 OK si l'évaluation est supprimée avec succès,
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
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Obtient la liste de toutes les évaluations à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des évaluations sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<RateDto>> GetAll()
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
    }
}