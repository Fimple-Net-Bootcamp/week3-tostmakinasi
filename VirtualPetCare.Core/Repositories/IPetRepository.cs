using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;

namespace VirtualPetCare.Core.Repositories
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<Pet> GetByIdWithOwnerAsync(int id);
        Task<IEnumerable<Pet>> GetAllWithRelation();
        
    }
}
