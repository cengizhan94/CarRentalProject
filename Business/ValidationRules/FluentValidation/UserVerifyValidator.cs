using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.ValidationRules.FluentValidation
{
    public class UserVerifyValidator : AbstractValidator<UserVerify>
    {
        public UserVerifyValidator()
        {
            RuleFor(u => u.EmailVerifyStatus).NotEqual(true);
            RuleFor(u => u.EmailVerifyToken).NotEmpty();
        }
    }
}
