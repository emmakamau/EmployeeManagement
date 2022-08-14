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
        [Route("department")]
        public IEnumerable<Department> GetDepartment()
        {
            return _context.Department;
        }

    }
}
