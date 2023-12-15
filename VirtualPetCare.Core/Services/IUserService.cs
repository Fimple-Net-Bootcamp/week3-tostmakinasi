using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.User;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// Interface defining user-related services.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously retrieves detailed information for a specific user based on their ID.
        /// </summary>
        /// <param name="id">ID of the user to retrieve.</param>
        Task<UserDto> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a list of all users.
        /// </summary>
        Task<IEnumerable<UserListDto>> GetAllAsync();

        /// <summary>
        /// Asynchronously creates a new user based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="entity">Data transfer object containing information for creating a new user.</param>
        Task<UserDto> CreateAsync(UserCreateDto entity);

        /// <summary>
        /// Asynchronously updates information for a specific user based on their ID.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="entity">Data transfer object containing updated information for the user.</param>
        Task UpdateAsync(int id, UserUpdateDto entity);

        /// <summary>
        /// Asynchronously removes a user based on their ID.
        /// </summary>
        /// <param name="id">ID of the user to remove.</param>
        Task RemoveAsync(int id);
    }

}
