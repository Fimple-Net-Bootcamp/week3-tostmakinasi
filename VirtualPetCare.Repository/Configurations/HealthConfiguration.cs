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
    public class HealthConfiguration : BaseEntityConfiguration<Health>
    {
        public void Configure(EntityTypeBuilder<Health> builder)
        {
            base.Configure(builder);

            builder.Property(h => h.Status).IsRequired().HasDefaultValue(100);
            builder.Property(h => h.IsAlive).IsRequired().HasDefaultValue(true);

        }
    }
}
