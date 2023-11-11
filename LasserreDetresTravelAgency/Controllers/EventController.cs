using LasserreDetresTravelAgency.Business.Service;
using LasserreDetresTravelAgency.Business;
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

        
        [HttpGet("{id}")]
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

        
        [HttpPut("{id}")]
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


        [HttpGet("all-events-by-destination")]
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
