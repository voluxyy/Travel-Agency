using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;

using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService service;
        
        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouveau commentaire en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données du commentaire à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si le commentaire est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CommentDto>> Add([FromBody] CommentDto dto)
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
        /// Récupère les détails d'un commentaire en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le commentaire n'existe pas,
        /// les détails du commentaire si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> Get(int id)
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
        /// Met à jour les détails d'un commentaire en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données du commentaire.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le commentaire n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CommentDto>> Update(int id, CommentDto dto)
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
        /// Supprime un commentaire en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du commentaire à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le commentaire n'existe pas,
        /// une réponse HTTP 200 OK si le commentaire est supprimé avec succès,
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
        /// Obtient la liste de tous les commentaires à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des commentaires sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<CommentDto>> GetAll()
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
        /// Obtient la liste de tous les commentaires associés à une destination en fonction de l'identifiant de la destination.
        /// </summary>
        /// <param name="id">L'identifiant de la destination pour laquelle récupérer les commentaires.</param>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des commentaires associés à la destination sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all-by-destination-id/{id}")]
        public ActionResult<List<CommentDto>> GetAllByDestinationId(int id)
        {
            try
            {
                return this.service.GetAllByDestinationId(id);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}