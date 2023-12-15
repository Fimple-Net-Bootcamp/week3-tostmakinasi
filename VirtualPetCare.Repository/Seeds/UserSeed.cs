using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, UserName = "JohnDoe", FirstName = "John", LastName = "Doe" },
                new User { Id = 2, UserName = "JaneDoe", FirstName = "Jane", LastName = "Doe" },
                new User { Id = 3, UserName = "Alice", FirstName = "Alice", LastName = "Doe" },
                new User { Id = 4, UserName = "Bob", FirstName = "Bob", LastName = "Doe" },
                new User { Id = 5, UserName = "Eve", FirstName = "Eve", LastName = "Doe" },
                new User { Id = 6, UserName = "Charlie", FirstName = "Charlie", LastName = "Doe" },
                new User { Id = 7, UserName = "David", FirstName = "David", LastName = "Doe" },
                new User { Id = 8, UserName = "Sophia", FirstName = "Sophia", LastName = "Doe" },
                new User { Id = 9, UserName = "Oliver", FirstName = "Oliver", LastName = "Doe" },
                new User { Id = 10, UserName = "Emma", FirstName = "Emma", LastName = "Doe" }
            );
        }
    }
}
