using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.AppUserValidator
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir Email adresi girin.");
        }
    }
}
