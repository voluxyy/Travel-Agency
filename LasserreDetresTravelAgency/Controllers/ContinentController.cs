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

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
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
