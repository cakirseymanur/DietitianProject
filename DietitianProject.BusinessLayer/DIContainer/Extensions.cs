using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.BusinessLayer.Concrete;
using DietitianProject.BusinessLayer.ValidationRules.AppRoleValidator;
using DietitianProject.BusinessLayer.ValidationRules.AppUserValidator;
using DietitianProject.BusinessLayer.ValidationRules.DietPlanValidator;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.EntityFramework;
using DietitianProject.DtoLayer.DTOs.AppRoleDTOs;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.DtoLayer.DTOs.DietPlanDTOs;
using DietitianProject.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ConteinerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();

            services.AddScoped<IDietPlanService, DietPlanManager>();
            services.AddScoped<IDietPlanDal, EFDietPlanDal>();
        }
        public static void CustomizeValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SignUpDto>, SignUpValidator>();
            services.AddTransient<IValidator<EmailConfirmedDto>, EmailConfirmedValidator>();
            services.AddTransient<IValidator<ForgotPasswordDto>, ForgotPasswordValidator>();
            services.AddTransient<IValidator<ResetPasswordDto>, ResetPasswordValidator>();
            services.AddTransient<IValidator<SignInDto>, SignInValidator>();
            services.AddTransient<IValidator<ProfileDto>, ProfileValidator>();


            services.AddTransient<IValidator<CreateRoleDto>, CreateRoleValidator>();
            services.AddTransient<IValidator<UpdateRoleDto>, UpdateRoleValidator>();

            services.AddTransient<IValidator<CreateDietPlanDto>, CreateDietPlanValidator>();
            services.AddTransient<IValidator<UpdateDietPlanDto>, UpdateDietPlanValidator>();
        }
    }
}
