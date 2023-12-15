using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Activity;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.DTOs.Health;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.DTOs.PetSpecies;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserListDto>();
            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<User, UserPetDetailDto>();
            //Pet
            CreateMap<Pet, PetListDto>()
                .ForMember(x => x.Age, opt => opt.MapFrom(src => CalculateAge(src.CreatedDate)))
                .ForMember(x => x.HealtStatus, opt => opt.MapFrom(src => src.Health.Status))
                .ForMember(x => x.Species, opt => opt.MapFrom(src => src.PetSpecies.Species));

            CreateMap<Pet, PetUserDetailDto>()
                .ForMember(x => x.Age, opt => opt.MapFrom(src => CalculateAge(src.CreatedDate)))
                .ForMember(x => x.HealtStatus, opt => opt.MapFrom(src => src.Health.Status))
                .ForMember(x => x.PetId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Pet,PetDto>()
                .ForMember(x => x.Age, opt => opt.MapFrom(src => CalculateAge(src.CreatedDate)))
                .ForMember(x => x.HealtStatus, opt => opt.MapFrom(src => src.Health.Status));
            CreateMap<PetCreateDto, Pet>();
            CreateMap<PetUpdateDto, Pet>();

            //Health
            CreateMap<Health, HealthDto>();
            
            //Activity
            CreateMap<ActivityCreateDto, Activity>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<Activity,ActivityForSpeciesDto>();

            //PetSpecies
            CreateMap<PetSpeciesForActivityCreateDto, PetSpecies>();
            CreateMap<PetSpecies, PetSpeciesDto>();

            //Food
            CreateMap<Food, FoodDto>();
        }

        private static string CalculateAge(DateTime createdDate)
        {
            double ageInDays = (DateTime.UtcNow - createdDate).TotalDays;

            return ageInDays < 365
                ? $"{Math.Round(ageInDays, 2)} Days Old"
                : $"{DateTime.UtcNow.Year - createdDate.Year} Years Old";
        }
    }
}
