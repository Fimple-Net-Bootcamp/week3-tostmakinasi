using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// Interface defining pet-related services.
    /// </summary>
    public interface IPetService
    {
        /// <summary>
        /// Asynchronously retrieves a list of all pets.
        /// </summary>
        Task<IEnumerable<PetListDto>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves detailed information for a specific pet based on its ID.
        /// </summary>
        /// <param name="id">ID of the pet to retrieve.</param>
        Task<PetDto> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously creates a new pet based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="entity">Data transfer object containing information for creating a new pet.</param>
        Task<PetDto> CreateAsync(PetCreateDto entity);

        /// <summary>
        /// Asynchronously updates information for a specific pet based on its ID.
        /// </summary>
        /// <param name="id">ID of the pet to update.</param>
        /// <param name="entity">Data transfer object containing updated information for the pet.</param>
        Task UpdateAsync(int id, PetUpdateDto entity);

        /// <summary>
        /// Asynchronously retrieves a list of pets owned by a specific owner based on the owner's ID.
        /// </summary>
        /// <param name="ownerId">ID of the owner whose pets are to be retrieved.</param>
        Task<IEnumerable<PetListDto>> GetByOwnerIdAsync(int ownerId);
    }

}
