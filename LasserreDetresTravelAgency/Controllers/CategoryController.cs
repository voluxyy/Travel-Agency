using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute une nouvelle catégorie en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données de la catégorie à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si la catégorie est ajoutée avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Add([FromBody] CategoryDto dto)
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
        /// Récupère les détails d'une catégorie en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si la catégorie n'existe pas,
        /// les détails de la catégorie si elle est trouvée,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
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
        /// Met à jour les détails d'une catégorie en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données de la catégorie.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si la catégorie n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, CategoryDto dto)
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
        /// Supprime une catégorie en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si la catégorie n'existe pas,
        /// une réponse HTTP 200 OK si la catégorie est supprimée avec succès,
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Obtient la liste de toutes les catégories à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des catégories sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<CategoryDto>> GetAll()
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