using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(Guid id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetAllStaff()
        {
            var staff = await _staffService.GetAllStaffAsync();
            return Ok(staff);
        }

        [HttpPost]
        public async Task<ActionResult> AddStaff(Staff staff)
        {
            await _staffService.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaffById), new { id = staff.Id }, staff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaff(Guid id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }

            await _staffService.UpdateStaffAsync(staff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(Guid id)
        {
            await _staffService.DeleteStaffAsync(id);
            return NoContent();
        }
    }
}
