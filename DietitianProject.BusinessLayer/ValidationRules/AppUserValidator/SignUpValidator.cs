using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.AppUserValidator
{
    public class SignUpValidator : AbstractValidator<SignUpDto>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Kullanıcı adı 4 karakterden fazla olmalı.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir Email adresi girin.");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsiyet boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre 8 karakterden küçük olamaz.");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Şifreler uyuşmuyor");
            RuleFor(x => x.checkBox).NotEqual(false).WithMessage("Kullanım şartlarını kabul etmelisiniz.");
        }
    }
}
