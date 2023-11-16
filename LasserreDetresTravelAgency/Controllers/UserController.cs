using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        
        public UserController(IUserService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur en utilisant les données fournies dans le corps de la requête.
        /// </summary>
        /// <param name="dto">Les données de l'utilisateur à ajouter.</param>
        /// <returns>
        /// Retourne une réponse HTTP 201 Created si l'utilisateur est ajouté avec succès,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Add([FromBody] UserDto dto)
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
        /// Récupère les détails d'un utilisateur en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à récupérer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'utilisateur n'existe pas,
        /// les détails de l'utilisateur si trouvé,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
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
        /// Met à jour les détails d'un utilisateur en fonction de son identifiant en utilisant les données fournies.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à mettre à jour.</param>
        /// <param name="dto">Les nouvelles données de l'utilisateur.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'utilisateur n'existe pas,
        /// une réponse de validation problématique en cas d'erreur de validation,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UserDto dto)
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
        /// Supprime un utilisateur en fonction de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur à supprimer.</param>
        /// <returns>
        /// Retourne une réponse HTTP 404 NotFound si l'utilisateur n'existe pas,
        /// une réponse HTTP 200 OK si l'utilisateur est supprimé avec succès,
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
        /// Obtient la liste de tous les utilisateurs à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des utilisateurs sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<UserDto>> GetAll()
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
        /// Obtient la liste de tous les voyageurs mineurs à partir du service, puis renvoie cette liste en tant qu'objet JSON.
        /// </summary>
        /// <returns>
        /// Retourne une réponse HTTP contenant la liste des voyageurs mineurs sous forme d'objet JSON,
        /// ou une réponse HTTP 500 Internal Server Error en cas d'erreur interne du serveur.
        /// </returns>
        [HttpGet("all-minor-travelers")]
        public ActionResult<List<UserDto>> GetAllMinorTravelers()
        {
            try
            {
                return this.service.GetAllMinorTravelers();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}