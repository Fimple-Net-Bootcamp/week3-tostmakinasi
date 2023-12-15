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
    public class FoodConfiguration : BaseEntityConfiguration<Food>
    {
        
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            base.Configure(builder);

            builder.Property(f => f.Name).IsRequired().HasMaxLength(255);
            builder.Property(f => f.HealthEffect).IsRequired();

            //builder.HasMany(f => f.PreferredPets)
            //       .WithMany(p => p.PreferredFoods)
            //       .UsingEntity(j => j.ToTable("FoodPreferredPets"));

            //builder.HasMany(f => f.HarmfulPets)
            //       .WithMany(p => p.HarmfulFoods)
            //       .UsingEntity(j => j.ToTable("FoodHarmfulPets"));

            builder.HasMany(f => f.FoodHistories)
                   .WithOne(fh => fh.Food)
                   .HasForeignKey(fh => fh.FoodId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
