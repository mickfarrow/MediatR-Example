using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DivesController : ControllerBase
    {
        private IDivesService _divesService;

        public DivesController(IDivesService divesService)
        {
            _divesService = divesService;
        }

        [HttpGet()]
        public ActionResult GetAll()
        {
            var dives = _divesService.GetDives();
            return Ok(dives);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dive = _divesService.GetDives().SingleOrDefault(x => x.Id == id);

            if (dive != null)
            {
                return Ok(dive);
            }

            return BadRequest("Dive does not exist");
        }

        [HttpPost()]
        public IActionResult Add([FromBody] Dive model)
        {
            return Ok(model);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Dive model)
        {
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"The dive with {id} was deleted");
        }

    }
}
