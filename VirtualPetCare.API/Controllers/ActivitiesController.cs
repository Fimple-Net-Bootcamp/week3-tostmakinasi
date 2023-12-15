using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs.Activity;
using VirtualPetCare.Core.Services;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpGet("{petId}")]
        public async Task<IActionResult> ActivitiesForPet(int petId)
        {
            var activities = await _activityService.ActivitiesForPet(petId);

            return Ok(activities);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityCreateDto entity)
        {
            var activity = await _activityService.CreateAsync(entity);

            return Ok(activity);
        }
    }
}
