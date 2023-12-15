using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Repository.Seeds
{
    internal class PetSeed : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(
                new Pet { Id = 1, OwnerId = 1, PetSpeciesId = 1, HealthId = 1, PetName = "Buddy" },
                new Pet { Id = 2, OwnerId = 2, PetSpeciesId = 2, HealthId = 2, PetName = "Whiskers" },
                new Pet { Id = 3, OwnerId = 3, PetSpeciesId = 3, HealthId = 3, PetName = "Tweety" },
                new Pet { Id = 4, OwnerId = 4, PetSpeciesId = 4, HealthId = 4, PetName = "Goldie" },
                new Pet { Id = 5, OwnerId = 5, PetSpeciesId = 1, HealthId = 5, PetName = "Fluffy" },
                new Pet { Id = 6, OwnerId = 6, PetSpeciesId = 2, HealthId = 6, PetName = "Speedy" },
                new Pet { Id = 7, OwnerId = 7, PetSpeciesId = 3, HealthId = 7, PetName = "Bugs" },
                new Pet { Id = 8, OwnerId = 8, PetSpeciesId = 4, HealthId = 8, PetName = "Mittens" },
                new Pet { Id = 9, OwnerId = 9, PetSpeciesId = 1, HealthId = 9, PetName = "Fido" },
                new Pet { Id = 10, OwnerId = 10, PetSpeciesId = 2, HealthId = 10, PetName = "Spike" }
            );
        }
    }
}
