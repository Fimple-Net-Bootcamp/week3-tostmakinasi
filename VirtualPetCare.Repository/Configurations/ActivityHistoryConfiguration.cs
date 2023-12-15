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
    public class ActivityHistoryConfiguration : BaseEntityConfiguration<ActivityHistory>
    {
        public void Configure(EntityTypeBuilder<ActivityHistory> builder)
        {
            base.Configure(builder);

            builder.HasOne(ah => ah.Activity)
                   .WithMany(a => a.ActivityHistories)
                   .HasForeignKey(ah => ah.ActivityId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ah => ah.Pet)
                   .WithMany(o => o.ActivityHistories)
                   .HasForeignKey(ah => ah.PetId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Activity - ActivityHistory ilişkisi
            builder.HasOne(ah => ah.Activity)
                .WithMany(a => a.ActivityHistories)
                .HasForeignKey(ah => ah.ActivityId);

            // Pet - ActivityHistory ilişkisi
            builder.HasOne(ah => ah.Pet)
                .WithMany(o => o.ActivityHistories)
                .HasForeignKey(ah => ah.PetId);
        }
    }
}
