using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.PetSpecies;

namespace VirtualPetCare.Service.Validations.PetSpecies
{
    public class PetSpeciesForActivityCreateDtoValidation : AbstractValidator<PetSpeciesForActivityCreateDto>
    {
        public PetSpeciesForActivityCreateDtoValidation()
        {
            RuleFor(x => x.Id).NotNull().InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0!");
        }
    }
}
