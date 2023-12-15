using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.DTOs.User;

namespace VirtualPetCare.Service.Validations.Pet
{
    public class PetCreatDtoValidation : AbstractValidator<PetCreateDto>
    {
        public PetCreatDtoValidation()
        {
            RuleFor(x => x.PetName).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.PetSpeciesId).NotNull().InclusiveBetween(1,int.MaxValue).WithMessage("{PropertyName} must be greater 0!");
            RuleFor(x => x.OwnerId).NotNull().InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0!");
        }
    }
}
