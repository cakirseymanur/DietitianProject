using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.AppUserValidator
{
    public class ProfileValidator:AbstractValidator<ProfileDto>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir Email adresi giriniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez.");
        }
    }
}
