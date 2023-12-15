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
    internal class ActivityConfiguration : BaseEntityConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Name).IsRequired().HasMaxLength(255);

            //builder.HasMany(a => a.PreferredPets)
            //       .WithMany(p => p.PreferredActivities)
            //       .UsingEntity(j => j.ToTable("ActivityPreferredPets"));

            builder.HasMany(a => a.ActivityHistories)
                   .WithOne(ah => ah.Activity)
                   .HasForeignKey(ah => ah.ActivityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
