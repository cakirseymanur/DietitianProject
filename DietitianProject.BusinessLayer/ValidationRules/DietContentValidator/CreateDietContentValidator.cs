using DietitianProject.DtoLayer.DTOs.DietContentDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.DietContentValidator
{
    public class CreateDietContentValidator : AbstractValidator<CreateDietContentDto>
    {
        public CreateDietContentValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Fotoğraf boş geçilemez.");
        }
    }
}
