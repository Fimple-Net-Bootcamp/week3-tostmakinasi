using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Repository.Configurations;
using VirtualPetCare.Repository.Seeds;

namespace VirtualPetCare.Repository.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PetSpecies> PetSpecies { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Health> HealthInformations { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<ActivityHistory> ActivityHistories { get; set; }
        public DbSet<FoodHistory> FoodHistories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new PetConfiguration());
            //modelBuilder.ApplyConfiguration(new OwnershipConfiguration());
            //modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            //modelBuilder.ApplyConfiguration(new HealthConfiguration());
            //modelBuilder.ApplyConfiguration(new FoodConfiguration());
            //modelBuilder.ApplyConfiguration(new ActivityHistoryConfiguration());
            //modelBuilder.ApplyConfiguration(new FoodHistoryConfiguration());

            ////Seeds

            //modelBuilder.ApplyConfiguration(new UserSeed());
            //modelBuilder.ApplyConfiguration(new PetSeed());
            //modelBuilder.ApplyConfiguration(new OwnershipSeed());
            //modelBuilder.ApplyConfiguration(new ActivitySeed());
            //modelBuilder.ApplyConfiguration(new HealthSeed());
            //modelBuilder.ApplyConfiguration(new FoodSeed());

        }
    }
}
