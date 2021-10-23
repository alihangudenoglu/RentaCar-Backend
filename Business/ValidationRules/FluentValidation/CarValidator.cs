using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            
            RuleFor(p => p.BrandId).NotEmpty().WithMessage("Marka alanı boş olmamalı");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Açıklama alanı boş olmamalı");
            RuleFor(p => p.ModelYear).NotEmpty().WithMessage("Yıl alanı boş olmamalı");
            RuleFor(p => p.DailyPrice).NotEmpty().WithMessage("Fiyat alanı boş olmamalı");

            RuleFor(p => p.DailyPrice).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı");
        }
    }
}
