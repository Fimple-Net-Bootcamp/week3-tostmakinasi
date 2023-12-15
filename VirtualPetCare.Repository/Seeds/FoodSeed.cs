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
    internal class FoodSeed : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(
            new Food { Id = 1, Name = "Chicken", HealthEffect = 10 },
            new Food { Id = 2, Name = "Fish", HealthEffect = 8 },
            new Food { Id = 3, Name = "Beef", HealthEffect = 12 },
            new Food { Id = 4, Name = "Vegetables", HealthEffect = 5 },
            new Food { Id = 5, Name = "Fruits", HealthEffect = 7 },
            new Food { Id = 6, Name = "Grains", HealthEffect = 6 },
            new Food { Id = 7, Name = "Milk", HealthEffect = 9 },
            new Food { Id = 8, Name = "Cheese", HealthEffect = 7 },
            new Food { Id = 9, Name = "Eggs", HealthEffect = 8 },
            new Food { Id = 10, Name = "Treats", HealthEffect = 3 }
        );
        }
    }
}
