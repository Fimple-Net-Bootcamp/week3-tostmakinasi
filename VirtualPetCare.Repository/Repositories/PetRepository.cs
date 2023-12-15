using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Repository.Context;

namespace VirtualPetCare.Repository.Repositories
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pet>> GetAllWithRelation()
        {
            var pets = await GetAll().Include(x=> x.Health).Include(x => x.PetSpecies).ToListAsync();
            return pets;
        }

        public async Task<Pet> GetByIdWithOwnerAsync(int id)
        {
            var pet = await _context.Pets.Include(x => x.Owner).Include(x=> x.Health).FirstOrDefaultAsync(x => x.Id == id);

            return pet;
        }
    }
}
