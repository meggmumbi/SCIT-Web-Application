using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(Guid id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpGet]
        public async Task<ActionResult<List<Activities>>> GetAllDepartment()
        {
            var departmnet = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departmnet);
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity(Department departmnet)
        {
            await _departmentService.AddDepartmentAsync(departmnet);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = departmnet.Id }, departmnet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(Guid id, Department departmnet)
        {
            if (id != departmnet.Id)
            {
                return BadRequest();
            }

            await _departmentService.UpdateDepartmentAsync(departmnet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(Guid id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}
