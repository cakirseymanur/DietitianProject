using DietitianProject.DtoLayer.DTOs.DietPlanDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.DietPlanValidator
{
    public class UpdateDietPlanValidator:AbstractValidator<UpdateDietPlanDto>
    {
        public UpdateDietPlanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez.");
        }
    }
}
