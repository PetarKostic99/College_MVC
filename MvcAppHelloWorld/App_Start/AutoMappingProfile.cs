using AutoMapper;
using BusinessObjectModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppHelloWorld
{
    public class AutoMappingProfile : Profile
    {
        public static MapperConfiguration Configure()
        {
            var mapperCofiguration = new MapperConfiguration(
                config =>
                {
                    //Mapping domen modeland view model in  both directions

                    config.CreateMap<Role, RoleViewModel>();
                    config.CreateMap<RoleViewModel, Role>();

                    config.CreateMap<Users, UsersViewModel>();
                    config.CreateMap<UsersViewModel, Users>();

                    config.CreateMap<HighSchool, HighSchoolViewModel>();
                    config.CreateMap<HighSchoolViewModel, HighSchool>();

                    config.CreateMap<College, CollegeViewModel>();
                    config.CreateMap<CollegeViewModel, College>();

                    config.CreateMap<Professor, ProfessorViewModel>();
                    config.CreateMap<ProfessorViewModel, Professor>();

                    config.CreateMap<ProfessorQueryViewModel, ProfessorQueryModel>();
                    config.CreateMap<ProfessorQueryModel, ProfessorQueryViewModel>();

                    config.CreateMap<HighSchoolStudentsQueryViewModel, HighSchoolStudentsQueryModel>();
                    config.CreateMap<HighSchoolStudentsQueryModel, HighSchoolStudentsQueryViewModel>();

                    config.CreateMap<CollegeStudentsQueryViewModel, CollegeStudentsQueryModel>();
                    config.CreateMap<CollegeStudentsQueryModel, CollegeStudentsQueryViewModel>();

                    config.CreateMap<RoleQueryViweModel, RoleQueryModel>();
                    config.CreateMap<RoleQueryModel, RoleQueryViweModel>();

                });
            return mapperCofiguration;
        }
    }
}