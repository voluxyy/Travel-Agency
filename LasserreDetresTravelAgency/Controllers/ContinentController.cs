using LasserreDetresTravelAgency.Business;
using LasserreDetresTravelAgency.Business.Service;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency
{
    [EnableCors(origins: "*", headers: "*", methods: "get, post, put, delete")]
    [Route("/api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private readonly IContinentService service;
        
        public ContinentController(IContinentService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new continent using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the continent to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the continent is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<ContinentDto>> Add([FromBody] ContinentDto dto)
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
        /// Retrieves the details of a continent based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the continent to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the continent does not exist,
        /// the details of the continent if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<ContinentDto>> Get(int id)
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
        /// Updates the details of a continent based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the continent to update.</param>
        /// <param name="dto">The new data of the continent.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the continent does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<ContinentDto>> Update(int id, ContinentDto dto)
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
        /// Deletes a continent based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the continent to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the continent does not exist,
        /// an HTTP 200 OK response if the continent is successfully deleted,
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
        /// Gets the list of all continents from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of continents as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<ContinentDto>> GetAll()
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