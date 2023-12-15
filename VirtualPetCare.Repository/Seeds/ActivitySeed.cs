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
    internal class ActivitySeed : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
            new Activity { Id = 1, Name = "Walking", HealthEffect = 20 },
            new Activity { Id = 2, Name = "Playing", HealthEffect = 30 },
            new Activity { Id = 3, Name = "Swimming", HealthEffect = 10 },
            new Activity { Id = 4, Name = "Running", HealthEffect = 20 },
            new Activity { Id = 5, Name = "Jumping", HealthEffect = 4 },
            new Activity { Id = 6, Name = "Sleeping", HealthEffect = 2 },
            new Activity { Id = 7, Name = "TugOfWar", HealthEffect = 1 },
            new Activity { Id = 8, Name = "Training", HealthEffect = 9 },
            new Activity { Id = 9, Name = "Chasing", HealthEffect = 5 }
        );
        
        }
    }
}
