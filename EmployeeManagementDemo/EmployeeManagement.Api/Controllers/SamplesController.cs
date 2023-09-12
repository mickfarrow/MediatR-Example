using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SamplesController : ControllerBase
    {
        public SamplesController() { }

        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                return Ok("Get all objects");
            }
            catch (Exception)
            {
                return BadRequest("This was a bad request");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok("Get an object by id");
            }
            catch (Exception)
            {
                return BadRequest("This was a bad request");
            }
        }

        [HttpPost()]
        public IActionResult Add([FromBody] object model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest("This was a bad request");
            }
        }

        [HttpPut()]
        public IActionResult Update([FromBody] object model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest("This was a bad request");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest("This was a bad request");
            }
        }

    }
}
