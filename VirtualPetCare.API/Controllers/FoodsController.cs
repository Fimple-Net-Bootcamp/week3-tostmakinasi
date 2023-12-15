using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.Services;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foods = await _foodService.GetAllWithDto();

            return Ok(foods);
        }

        [HttpPost("{petId}")]
        public async Task<IActionResult> FeedPetById(int petId, [FromBody] FoodFeedingDto food)
        {
            await _foodService.FeedPetById(petId, food);
            return Ok();
        }
    }
}
