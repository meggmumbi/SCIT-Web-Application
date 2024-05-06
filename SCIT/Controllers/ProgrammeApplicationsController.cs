using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgrammeApplicationsController : ControllerBase
    {
        private readonly ProgrammeApplicationsService _applicationService;

        public ProgrammeApplicationsController(ProgrammeApplicationsService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgrammeApplications>> GetApplicationById(Guid id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProgrammeApplications>>> GetAllApplications()
        {
            var application = await _applicationService.GetAllApplicationsAsync();
            return Ok(application);
        }

        [HttpPost]
        public async Task<ActionResult> AddApplications(ProgrammeApplications application)
        {
            await _applicationService.AddApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApplication(Guid id, ProgrammeApplications application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            await _applicationService.UpdateApplicationAsync(application);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplication(Guid id)
        {
            await _applicationService.DeleteApplicationAsync(id);
            return NoContent();
        }
    }
}
