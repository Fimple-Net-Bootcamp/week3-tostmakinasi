using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.DTOs.Health;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// Interface for health-related services, extending the general service operations.
    /// </summary>
    public interface IHealthService : IService<Health>
    {
        /// <summary>
        /// Asynchronously updates health information based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="petId">ID of the pet associated with the health information</param>
        /// <param name="entity">Data transfer object containing updated health information.</param>
        Task UpdateWithDtoAsync(int petId, HealthUpdateDto entity);

        /// <summary>
        /// Asynchronously retrieves health information based on the specified pet ID.
        /// </summary>
        /// <param name="petId">ID of the pet associated with the health information.</param>
        /// <returns>Data transfer object representing the health information of the specified pet.</returns>
        Task<HealthDto> GetByPetIdAsync(int petId);

        /// <summary>
        /// Applies the feeding effects of a specific food to the health of a pet.
        /// </summary>
        /// <param name="petId">Identifier of the pet to apply the feeding.</param>
        /// <param name="food">DTO representing the food to be applied.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        Task ApplyFeedToHealthAsync(int petId, FoodDto food);
    }

}
