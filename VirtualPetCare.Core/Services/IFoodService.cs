using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// Service interface for managing pet food.
    /// </summary>
    public interface IFoodService : IService<Food>
    {
        /// <summary>
        /// Retrieves a list of all available pet foods.
        /// </summary>
        /// <returns>List of DTOs representing pet foods.</returns>
        Task<List<FoodDto>> GetAllWithDto();

        /// <summary>
        /// Feeds a pet with the specified identifier.
        /// </summary>
        /// <param name="petId">Identifier of the pet to be fed.</param>
        Task FeedPetById(int petId, FoodFeedingDto food);
    }

}
