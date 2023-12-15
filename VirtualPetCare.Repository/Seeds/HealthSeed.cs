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
    internal class HealthSeed : IEntityTypeConfiguration<Health>
    {
        public void Configure(EntityTypeBuilder<Health> builder)
        {
            builder.HasData(
            new Health { Id = 1, Status = 75, IsAlive = true },
            new Health { Id = 2, Status = 80, IsAlive = true },
            new Health { Id = 3, Status = 65, IsAlive = true },
            new Health { Id = 4, Status = 90, IsAlive = true },
            new Health { Id = 5, Status = 70, IsAlive = true },
            new Health { Id = 6, Status = 85, IsAlive = true },
            new Health { Id = 7, Status = 60, IsAlive = true },
            new Health { Id = 8, Status = 95, IsAlive = true },
            new Health { Id = 9, Status = 72, IsAlive = true },
            new Health { Id = 10, Status = 88, IsAlive = true }
        );
        }
    }
}
