using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.AppUserValidator
{
    public class EmailConfirmedValidator : AbstractValidator<EmailConfirmedDto>
    {
        public EmailConfirmedValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir Email adresi girin.");
            RuleFor(x => x.MailCode).NotEmpty().WithMessage("Onay kodu boş geçilemez.");

        }
    }
}
