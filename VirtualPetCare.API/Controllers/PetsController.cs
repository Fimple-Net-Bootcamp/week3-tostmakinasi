using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petService.GetAllAsync();

            return Ok(pets);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetById))]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petService.GetByIdAsync(id);

            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PetCreateDto entity)
        {
            var pet = await _petService.CreateAsync(entity);

            return CreatedAtAction(nameof(PetsController.GetById), new { id = pet.Id }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PetUpdateDto entity)
        {
            await _petService.UpdateAsync(id,entity);

            return Ok();
        }
    }
}
