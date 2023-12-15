using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;

namespace VirtualPetCare.Service.Validations.Pet
{
    public class PetUpdateDtoValidation : AbstractValidator<PetUpdateDto>
    {
        public PetUpdateDtoValidation()
        {
            RuleFor(x => x.PetName).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
