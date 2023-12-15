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
    public class FoodHistoryConfiguration : BaseEntityConfiguration<FoodHistory>
    {
        public void Configure(EntityTypeBuilder<FoodHistory> builder)
        {
            base.Configure(builder);

            builder.HasOne(fh => fh.Food)
                   .WithMany(f => f.FoodHistories)
                   .HasForeignKey(fh => fh.FoodId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(fh => fh.Pet)
                   .WithMany(o => o.FoodHistories)
                   .HasForeignKey(fh => fh.PetId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
