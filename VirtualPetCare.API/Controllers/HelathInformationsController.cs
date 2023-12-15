using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs.Health;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HelathInformationsController : ControllerBase
    {
        private readonly IHealthService _service;

        public HelathInformationsController(IHealthService service)
        {
            _service = service;
        }

        [HttpGet("{petId}")]
        public async Task<IActionResult> GetByPetId(int petId) 
        {
            var healtInformation = await _service.GetByPetIdAsync(petId);
            
            return Ok(healtInformation);
        }

        [HttpPatch("{petId}")]
        public async Task<IActionResult> PatchHealth(int petId, [FromBody] JsonPatchDocument<HealthUpdateDto> patchDocument)
        {
            var newHealthUpdateDto = new HealthUpdateDto();

            patchDocument.ApplyTo(newHealthUpdateDto, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateWithDtoAsync(petId, newHealthUpdateDto);

            return NoContent();
        }
    }
}
