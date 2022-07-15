using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    internal class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
