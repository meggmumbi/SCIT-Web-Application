using Microsoft.AspNetCore.Mvc;
using SCIT.Entities;
using SCIT.Services;

namespace SCIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivitiesService _activitiesService;

        public ActivitiesController(ActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activities>> GetActivityById(Guid id)
        {
            var activity = await _activitiesService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpGet]
        public async Task<ActionResult<List<Activities>>> GetAllActivities()
        {
            var activity = await _activitiesService.GetAllActivitiesAsync();
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity(Activities activity)
        {
            await _activitiesService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(Guid id, Activities activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            await _activitiesService.UpdateActivityAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            await _activitiesService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
