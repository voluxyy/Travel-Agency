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
        /// Adds a new favorite using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the favorite to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the favorite is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Retrieves the details of a favorite based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the favorite to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the favorite does not exist,
        /// the details of the favorite if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Updates the details of a favorite based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the favorite to update.</param>
        /// <param name="dto">The new data of the favorite.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the favorite does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Deletes a favorite based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the favorite to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the favorite does not exist,
        /// an HTTP 200 OK response if the favorite is successfully deleted,
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
        /// Gets the list of all favorites from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of favorites as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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