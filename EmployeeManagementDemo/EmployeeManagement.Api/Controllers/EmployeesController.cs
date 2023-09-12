using EmployeeManagementLibrary.Queries;
using EmployeeManagement.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using EmployeeManagementLibrary.Models;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public ActionResult GetAll()
        {
            var employees = _mediator.Send(new GetEmployeeListRequest());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var request = new GetEmployeeRequest(id);
            var employee = _mediator.Send(request);
            return Ok(employee);
        }
    }
}
