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
        /// Adds a new travel type using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the travel type to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the travel type is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Retrieves the details of a travel type based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel type to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the travel type does not exist,
        /// the details of the travel type if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Updates the details of a travel type based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the travel type to update.</param>
        /// <param name="dto">The new data of the travel type.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the travel type does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Deletes a travel type based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel type to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the travel type does not exist,
        /// an HTTP 200 OK response if the travel type is successfully deleted,
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
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Gets the list of all travel types from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of travel types as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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