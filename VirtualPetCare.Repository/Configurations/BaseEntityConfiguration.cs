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
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.CreatedDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(e => e.UpdatedDate).IsRequired(false);
            builder.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasQueryFilter(x => x.IsActive == true);//Sadece aktif olan kayıtların gelmesini sağlıyor
        }
    }
}
