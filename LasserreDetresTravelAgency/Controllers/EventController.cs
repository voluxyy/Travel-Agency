using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;
using LasserreDetresTravelAgency.Business.Dto;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new event using the data provided in the request body.
        /// </summary>
        /// <param name="dto">The data of the event to add.</param>
        /// <returns>
        /// Returns an HTTP 201 Created response if the event is successfully added,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<EventDto>> Add([FromBody] EventDto dto)
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
        /// Retrieves the details of an event based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to retrieve.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the event does not exist,
        /// the details of the event if found,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("get/{id}")]
        public async Task<ActionResult<EventDto>> Get(int id)
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
        /// Updates the details of an event based on its identifier using the provided data.
        /// </summary>
        /// <param name="id">The identifier of the event to update.</param>
        /// <param name="dto">The new data of the event.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the event does not exist,
        /// a problematic validation response in case of validation error,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpPut("update/{id}")]
        public async Task<ActionResult<EventDto>> Update(int id, EventDto dto)
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
        /// Deletes an event based on its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to delete.</param>
        /// <returns>
        /// Returns an HTTP 404 NotFound response if the event does not exist,
        /// an HTTP 200 OK response if the event is successfully deleted,
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
        /// Gets the list of all events from the service and then returns this list as a JSON object.
        /// </summary>
        /// <returns>
        /// Returns an HTTP response containing the list of events as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("all")]
        public ActionResult<List<EventDto>> GetAll()
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
        /// Gets the list of all events related to a specific destination from the service,
        /// then returns this list as a JSON object.
        /// </summary>
        /// <param name="id">The identifier of the destination.</param>
        /// <returns>
        /// Returns an HTTP response containing the list of events related to the destination as a JSON object,
        /// or an HTTP 500 Internal Server Error response in case of server internal error.
        /// </returns>
        [HttpGet("all-events-by-destination/{id}")]
        public ActionResult<List<EventDto>> GetAllEventByDest(int id)
        {
            try
            {
                return this.service.GetAllEventByDest(id);
            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}