using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService service;
        
        public CountryController(ICountryService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouveau pays en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données du pays à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si le pays est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<CountryDto>> Add([FromBody] CountryDto dto)
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
        /// Récupère les détails d'un pays en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du pays à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le pays n'existe pas,
        /// les détails du pays si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<CountryDto>> Get(int id)
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
        /// Met à jour les détails d'un pays en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant du pays à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données du pays.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le pays n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<CountryDto>> Update(int id, CountryDto dto)
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
        /// Supprime un pays en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du pays à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si le pays n'existe pas,
        /// une réponse HTTP 200 OK si le pays est supprimé avec succès,
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
        /// Obtient la liste de tous les pays à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des pays sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<CountryDto>> GetAll()
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