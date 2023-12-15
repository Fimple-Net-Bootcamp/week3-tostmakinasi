using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.User;

namespace VirtualPetCare.Service.Validations.User
{
    public class UserCreatDtoValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreatDtoValidation()
        {
            RuleFor(x=> x.UserName).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");

        }
    }
}
