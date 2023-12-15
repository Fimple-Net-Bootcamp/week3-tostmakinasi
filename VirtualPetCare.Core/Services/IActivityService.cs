using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Activity;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// Service interface for managing activities.
    /// </summary>
    public interface IActivityService : IService<Activity>
    {
        /// <summary>
        /// Creates a new activity based on the provided data.
        /// </summary>
        /// <param name="entity">Data for creating the activity.</param>
        /// <returns>DTO representing the created activity.</returns>
        Task<ActivityDto> CreateAsync(ActivityCreateDto entity);

        /// <summary>
        /// Retrieves a list of activities available for a specific pet species.
        /// </summary>
        /// <param name="petId">Identifier of the pet.</param>
        /// <returns>List of DTOs representing activities for the specified pet species.</returns>
        Task<List<ActivityForSpeciesDto>> ActivitiesForPet(int petId);
    }

}
