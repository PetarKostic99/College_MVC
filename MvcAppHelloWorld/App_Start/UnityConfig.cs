using DataAccess;
using BusinessLayer;
using BusinessObjectModel;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using AutoMapper;

namespace MvcAppHelloWorld
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //IGenericRepository - Repository
            container.RegisterType<IGenericRepository<HighSchool>, HighSchoolRepository>();
            container.RegisterType<IGenericRepository<College>, CollegeRepository>();
            container.RegisterType<IGenericRepository<Role>, RolesRepository>();
            container.RegisterType<IGenericRepository<Professor>, ProfesssorRepository>();
            container.RegisterType<IGenericRepository<Users>, UserRepository>();

            //IGenericRepository - QueryRepository
            container.RegisterType<IGenericRepository<HighSchoolStudentsQueryModel>, HighSchoolStudentsQueryRepository>();
            container.RegisterType<IGenericRepository<ProfessorQueryModel>, ProfessorQueryRepository>();
            container.RegisterType<IGenericRepository<CollegeStudentsQueryModel>, CollegeStudentsQueryRepository>();
            
            //GenericService
            container.RegisterType<IGenericService<HighSchool>, HighSchoolService>();
            container.RegisterType<IGenericService<College>, CollegeService>();
            container.RegisterType<IGenericService<Role>, RolesService>();
            container.RegisterType<IGenericService<Professor>, ProfessorService>();
            container.RegisterType<IGenericService<Users>, UserService>();

            //IGenericRepository - GenericService<Query Type>
            container.RegisterType<IGenericService<ProfessorQueryModel>, GenericService<ProfessorQueryModel>>();
            container.RegisterType<IGenericService<HighSchoolStudentsQueryModel>, GenericService<HighSchoolStudentsQueryModel>>();
            container.RegisterType<IGenericService<CollegeStudentsQueryModel>, GenericService<CollegeStudentsQueryModel>>();

            //IGenericAppService - AppService
            container.RegisterType<IGenericAppService<UsersViewModel, Users>, UserAppService>();
            container.RegisterType<IGenericAppService<HighSchoolViewModel, HighSchool>, HighSchoolAppService>();
            container.RegisterType<IGenericAppService<CollegeViewModel, College>, CollegeAppService>();
            container.RegisterType<IGenericAppService<RoleViewModel, Role>, RoleAppService>();
            container.RegisterType<IGenericAppService<ProfessorViewModel, Professor>, ProfessorAppService>();

            //IGenericAppService - GenericAppservice<ViewModelType, Querytype>
            container.RegisterType<IGenericAppService<HighSchoolStudentsQueryViewModel, HighSchoolStudentsQueryModel>, GenericAppService<HighSchoolStudentsQueryViewModel, HighSchoolStudentsQueryModel>>();
            container.RegisterType<IGenericAppService<CollegeStudentsQueryViewModel, CollegeStudentsQueryModel>, GenericAppService<CollegeStudentsQueryViewModel, CollegeStudentsQueryModel>>();
            container.RegisterType<IGenericAppService<ProfessorQueryViewModel, ProfessorQueryModel>, GenericAppService<ProfessorQueryViewModel, ProfessorQueryModel>>();


            // e.g. container.RegisterType<ITestService, TestService>();

            MapperConfiguration config = AutoMappingProfile.Configure();
            IMapper mapper = config.CreateMapper();

            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}