using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Infrastructure;
using Core.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesResource : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesResource(IUnitOfWork unitOfWork)
        {
    
            _unitOfWork = unitOfWork;
        }

        // GET: api/EmployeesResource
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.Employees.GetAll();
        }

        // GET: api/EmployeesResource/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee =  _unitOfWork.Employees.GetAll().SingleOrDefault(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/EmployeesResource/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Employees.Update(employee);

            try
            {
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesResource
        [HttpPost]
        public  IActionResult PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/EmployeesResource/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee =  _unitOfWork.Employees.GetAll().SingleOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            _unitOfWork.Employees.Remove(employee);
            _unitOfWork.Complete();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _unitOfWork.Employees.GetAll().Any(e => e.Id == id);
        }
    }
}