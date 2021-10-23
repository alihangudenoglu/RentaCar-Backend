using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad alanı boş olmamalı");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("SoyAd alanı boş olmamalı");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email alanı boş olmamalı");
           // RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre alanı boş olmamalı");

            RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad alanı 2 harfden fazla olmalı");
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("SoyAd alanı 2 harfden fazla olmalı");

           // RuleFor(p=>p.Password).MinimumLength(8).MaximumLength(16).WithMessage("Şifre min 8 max 16 karakter olmalı");
        }
    }
}
