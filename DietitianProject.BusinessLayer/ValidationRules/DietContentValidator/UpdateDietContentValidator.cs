using DietitianProject.DtoLayer.DTOs.DietContentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.DietContentValidator
{
    public class UpdateDietContentValidator : AbstractValidator<UpdateDietContentDto>
    {
        public UpdateDietContentValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez.");
        }
    }
}
