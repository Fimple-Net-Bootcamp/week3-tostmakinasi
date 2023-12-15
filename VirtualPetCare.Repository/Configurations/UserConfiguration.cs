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
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(255);

            builder.HasMany(u => u.Pets)
                   .WithOne(o => o.Owner)
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
