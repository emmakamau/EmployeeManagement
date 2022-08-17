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
    }
}
