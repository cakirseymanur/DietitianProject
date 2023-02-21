using AutoMapper;
using DietitianProject.DtoLayer.DTOs.AppRoleDTOs;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.DtoLayer.DTOs.DietContentDTOs;
using DietitianProject.DtoLayer.DTOs.DietPlanDTOs;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Mapping.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<SignUpDto, AppUser>().ReverseMap();
            CreateMap<ForgotPasswordDto, AppUser>().ReverseMap();
            CreateMap<ResetPasswordDto, AppUser>().ReverseMap();
            CreateMap<EmailConfirmedDto, AppUser>().ReverseMap();
            CreateMap<SignInDto, AppUser>().ReverseMap();
            CreateMap<ProfileDto, AppUser>().ReverseMap();

            //////////AppRole///////////////////////
            CreateMap<CreateRoleDto, AppRole>().ReverseMap();
            CreateMap<UpdateRoleDto, AppRole>().ReverseMap();

            /////////DietPlan/////////////////
            CreateMap<CreateDietPlanDto, DietPlan>().ReverseMap();
            CreateMap<UpdateDietPlanDto, DietPlan>().ForMember(dto=>dto.ImageUrl,plan=>plan.Ignore()).ForMember(dto=>dto.CreatedDate,plan=>plan.Ignore()).ReverseMap();

            /////////DietContent/////////////////
            CreateMap<CreateDietContentDto, DietContent>().ReverseMap();
            CreateMap<UpdateDietContentDto, DietContent>().ForMember(dto => dto.ImageUrl, plan => plan.Ignore()).ForMember(dto => dto.CreatedDate, plan => plan.Ignore()).ReverseMap();
        }
    }
}
