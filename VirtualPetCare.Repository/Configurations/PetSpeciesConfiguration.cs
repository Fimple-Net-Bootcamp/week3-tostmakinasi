using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Repository.Configurations
{
    public class PetSpeciesConfiguration : BaseEntityConfiguration<PetSpecies>
    {
        public void Configure(EntityTypeBuilder<PetSpecies> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Species).IsRequired().HasMaxLength(100);

            //builder.HasMany(p => p.PreferredActivities)
            //       .WithMany(a => a.PreferredPets)
            //       .UsingEntity(j => j.ToTable("PetPreferredActivities"));

            //builder.HasMany(p => p.PreferredFoods)
            //       .WithMany(f => f.PreferredPets)
            //       .UsingEntity(j => j.ToTable("PetPreferredFoods"));

            //builder.HasMany(p => p.HarmfulFoods)
            //       .WithMany(f => f.HarmfulPets)
            //       .UsingEntity(j => j.ToTable("PetHarmfulFoods"));

            builder.HasMany(p => p.Pets)
                   .WithOne(o => o.PetSpecies)
                   .HasForeignKey(o => o.PetSpeciesId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Activities).WithMany(x => x.PetSpecies).UsingEntity(j => j.ToTable("PetSpeciesActivities"));
            
        }
    }
}
