using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Asynchronously retrieves an entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity with the specified ID.</returns>
        Task<User> GetByIdWithOwnershipsAsync(int id);
    }
}
