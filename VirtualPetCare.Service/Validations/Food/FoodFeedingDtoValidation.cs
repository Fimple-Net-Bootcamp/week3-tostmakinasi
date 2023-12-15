using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Food;

namespace VirtualPetCare.Service.Validations.Food
{
    public class FoodFeedingDtoValidation:AbstractValidator<FoodFeedingDto>
    {
        public FoodFeedingDtoValidation()
        {
            RuleFor(x => x.FoodId).NotNull().InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0!");
        }
    }
}
