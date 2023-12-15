using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Repository.Seeds
{
    internal class PetSpeciesSeed : IEntityTypeConfiguration<PetSpecies>
    {
        public void Configure(EntityTypeBuilder<PetSpecies> builder)
        {
            builder.HasData(
            new PetSpecies { Id = 1, Species = "Dog" },
            new PetSpecies { Id = 2, Species = "Cat" },
            new PetSpecies { Id = 3, Species = "Bird" }
        );
        }
    }
}
