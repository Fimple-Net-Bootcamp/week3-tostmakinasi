using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Activity;
using VirtualPetCare.Service.Validations.PetSpecies;

namespace VirtualPetCare.Service.Validations.Activity
{
    public class ActivityCreateDtoValidation : AbstractValidator<ActivityCreateDto>
    {
        public ActivityCreateDtoValidation()
        {
            RuleFor(x => x.Name)
            .NotNull().NotEmpty()
            .WithMessage("{PropertyName} is required!");

            RuleFor(x => x.HealthEffect)
                .NotNull().InclusiveBetween(1, 100)
                .WithMessage("{PropertyName} must be greater than 0 and less than 100!");

            RuleFor(x => x.PetSpeciesIds)
                .NotNull().WithMessage("{PropertyName} is required!")
                .Must(x => x != null && x.Any())
                .WithMessage("{PropertyName} must contain at least one item.");

            RuleForEach(x => x.PetSpeciesIds)
                .SetValidator(new PetSpeciesForActivityCreateDtoValidation());
        }
    }
}
