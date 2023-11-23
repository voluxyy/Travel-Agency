using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
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
        /// Adds a new destination using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the destination to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the destination is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
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
        /// Retrieves the details of a destination based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the destination does not exist,
        /// the details of the destination if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("get/{id}")]
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
        /// Updates the details of a destination based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the destination to update.</param>
        /// <param name="dto">The new data of the destination.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the destination does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPut("update/{id}")]
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
        /// Deletes a destination based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the destination does not exist,
        /// an HTTP 200 OK response if the destination is successfully deleted,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Gets the list of all destinations from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of destinations as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<DestinationDto>> GetAll()
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
        /// Gets the list of all visited destinations from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of visited destinations as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("all-visited")]
        public ActionResult<List<DestinationDto>> GetAllVisited()
        {
            try
            {
                return this.service.GetAllVisited();
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the list of all destinations associated with a user and category based on the user and category identifiers.
        /// </summary>
        /// <param name="userId">The identifier of the user.</param>
        /// <param name="CategoryId">The identifier of the category.</param>
        /// <returns>
        /// Returns an HTTP response containing the list of destinations associated with the user and category as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("get-all-user-and-category/{userId}/{CategoryId}")]
        public ActionResult<List<DestinationDto>> GetAllDestinationByUserAndCategory(int userId, int CategoryId)
        {
            try
            {
                return this.service.GetAllDestinationByUserAndCategory(userId, CategoryId);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}