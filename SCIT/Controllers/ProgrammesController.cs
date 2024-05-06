using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgrammesController : ControllerBase
    {
        private readonly ProgrammesService _programmesService;

        public ProgrammesController(ProgrammesService programmesService)
        {
            _programmesService = programmesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programmes>> GetProgrammeById(Guid id)
        {
            var programme = await _programmesService.GetProgrammeByIdAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            return Ok(programme);
        }

        [HttpGet]
        public async Task<ActionResult<List<Programmes>>> GetAllProgrammes()
        {
            var programmes = await _programmesService.GetAllProgrammesAsync();
            return Ok(programmes);
        }

        [HttpPost]
        public async Task<ActionResult> AddProgramme(Programmes programme)
        {
            await _programmesService.AddProgrammeAsync(programme);
            return CreatedAtAction(nameof(GetProgrammeById), new { id = programme.Id }, programme);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProgramme(Guid id, Programmes programme)
        {
            if (id != programme.Id)
            {
                return BadRequest();
            }

            await _programmesService.UpdateProgrammeAsync(programme);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProgramme(Guid id)
        {
            await _programmesService.DeleteProgrammeAsync(id);
            return NoContent();
        }
    }
}
