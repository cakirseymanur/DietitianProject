using DietitianProject.DtoLayer.DTOs.DietPlanDTOs; 
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.DietPlanValidator
{
    public class CreateDietPlanValidator : AbstractValidator<CreateDietPlanDto>
    {
        public CreateDietPlanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Fotoğraf boş geçilemez.");
            RuleFor(x => x.Pdf).NotEmpty().WithMessage("Pdf boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez.");
        }
    }
}
