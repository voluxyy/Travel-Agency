using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace LasserreDetresTravelAgency.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelsService service;
        public TravelsController(ITravelsService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TravelsDto>> Add([FromBody] TravelsDto dto)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TravelsDto>> Get(int id)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<TravelsDto>> Update(int id, TravelsDto dto)
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

        [HttpGet("all")]
        public ActionResult<List<TravelsDto>> GetAll()
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

        [HttpGet("all-future-date")]
        public ActionResult<List<TravelsDto>> GetAllGetAllFutureTravels()
        {
            try
            {
                return this.service.GetAllFutureTravels();

            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("all-paste-date")]
        public ActionResult<List<TravelsDto>> GetAllPasteTravels()
        {
            try
            {
                return this.service.GetAllPasteTravels();

            }
            catch (Exception)
            {
                return this.StatusCode(500, "Internal Server Error");
            }
        }
    }
}
