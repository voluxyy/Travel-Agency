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
