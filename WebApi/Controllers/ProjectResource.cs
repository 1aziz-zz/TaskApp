using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectResource : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectResource(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _unitOfWork.Projects.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetProject([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _unitOfWork.Projects.GetAll().SingleOrDefault(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        public IActionResult PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Projects.Update(project);

            try
            {
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        [HttpPost]
        public IActionResult PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Projects.Add(project);
            _unitOfWork.Complete();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _unitOfWork.Projects.GetAll().SingleOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            _unitOfWork.Projects.Remove(project);
            _unitOfWork.Complete();

            return Ok(project);
        }

        private bool ProjectExists(int id)
        {
            return _unitOfWork.Projects.GetAll().Any(e => e.Id == id);
        }
    }
}
