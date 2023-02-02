using DietitianProject.DtoLayer.DTOs.AppRoleDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.ValidationRules.AppRoleValidator
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rol boş geçilemez.");
        }
    }
}
