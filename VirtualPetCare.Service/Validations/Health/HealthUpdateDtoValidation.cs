using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Health;

namespace VirtualPetCare.Service.Validations.Health
{
    public class HealthUpdateDtoValidation : AbstractValidator<HealthUpdateDto>
    {
        public HealthUpdateDtoValidation()
        {
            RuleFor(x => x.Status).NotNull().InclusiveBetween(1, 100).WithMessage("{PropertyName} must be greater 0 and less than 100!");
        }
    }
}
