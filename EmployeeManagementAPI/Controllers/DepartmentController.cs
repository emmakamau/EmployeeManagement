using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly EManagementContext _context;

        public DepartmentController(ILogger<DepartmentController> logger, EManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Departments);
        }

        // GET: api/Department/5
        [HttpGet("{id}", Name = "GetDepartment")]
        public IActionResult Get(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            _context.Departments.Add(department);
            _context.SaveChanges();
            return CreatedAtRoute("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Department/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return NoContent();
        }

        // Patch: api/Department/4
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            var departmentToUpdate = _context.Departments.Find(id);
            if (departmentToUpdate == null)
            {
                return NotFound();
            }
            departmentToUpdate.DepartmentName = department.DepartmentName;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
