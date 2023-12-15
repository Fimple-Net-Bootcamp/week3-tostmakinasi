using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;
using System.Reflection.Emit;

namespace VirtualPetCare.Repository.Configurations
{
    public class PetConfiguration : BaseEntityConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            base.Configure(builder);


            // User - Pet ilişkisi
            builder.HasOne(o => o.Owner)
                   .WithMany(u => u.Pets)
                   .HasForeignKey(o => o.OwnerId);

            // PetSpecies - PEt ilişkisi
            builder.HasOne(o => o.PetSpecies)
                   .WithMany(p => p.Pets)
                   .HasForeignKey(o => o.PetSpeciesId);

            // Health - Pet ilişkisi
            builder.HasOne(p => p.Health)
                    .WithOne()
                    .HasForeignKey<Health>(h => h.Id)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.ActivityHistories)
                   .WithOne(ah => ah.Pet)
                   .HasForeignKey(ah => ah.PetId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.FoodHistories)
                   .WithOne(fh => fh.Pet)
                   .HasForeignKey(fh => fh.PetId)
                   .OnDelete(DeleteBehavior.Cascade);

           

        }
    }
}
