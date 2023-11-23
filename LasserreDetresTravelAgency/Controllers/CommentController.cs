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
        /// Adds a new comment using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the comment to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the comment is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Retrieves the details of a comment based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the comment to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the comment does not exist,
        /// the details of the comment if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("get/{id}")]
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
        /// Updates the details of a comment based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the comment to update.</param>
        /// <param name="dto">The new data of the comment.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the comment does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPut("update/{id}")]
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
        /// Deletes a comment based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the comment to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the comment does not exist,
        /// an HTTP 200 OK response if the comment is successfully deleted,
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
        /// Gets the list of all comments from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of comments as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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
        /// Gets the list of all comments associated with a destination based on the destination identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination for which to retrieve the comments.</param>
        /// <returns>
        /// Returns an HTTP response containing the list of comments associated with the destination as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
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