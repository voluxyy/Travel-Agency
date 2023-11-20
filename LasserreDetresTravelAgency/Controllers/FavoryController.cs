using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FavoryController : ControllerBase
    {
        private readonly IFavoryService service;

        public FavoryController(IFavoryService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouveau favori en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données du favori à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si le favori est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<FavoryDto>> Add([FromBody] FavoryDto dto)
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
        /// Récupère les détails d'un favori en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du favori à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le favori n'existe pas,
        /// les détails du favori si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<FavoryDto>> Get(int id)
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
        /// Met à jour les détails d'un favori en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant du favori à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données du favori.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le favori n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<FavoryDto>> Update(int id, FavoryDto dto)
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
        /// Supprime un favori en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du favori à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le favori n'existe pas,
        /// une réponse HTTP 200 OK si le favori est supprimé avec succès,
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
        /// Obtient la liste de tous les favoris à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des favoris sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<FavoryDto>> GetAll()
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