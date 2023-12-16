using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;
using VirtualPetCare.Repository.Repositories;
using VirtualPetCare.Repository.UnitOfWorks;
using VirtualPetCare.Service.Services;

namespace VirtualPetCare.API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddScopedWithExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IHealthService, HealthService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IFoodService, FoodService>();

            return services;
        }
    }
}
