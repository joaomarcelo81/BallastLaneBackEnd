
using BallastLaneBackEnd.Application;
using BallastLaneBackEnd.Domain.Entities;
using BallastLaneBackEnd.Domain.Interfaces.Repositories;
using BallastLaneBackEnd.Domain.Interfaces.Services;
using BallastLaneBackEnd.Infra.Repositories;
using BallastLaneBackEnd.Infra.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BallastLaneBackEnd.CrossCutting.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            //  services.RegisterAutoMapper();
            services.RegisterServices();
            services.RegisterRespository();
            return services;
        }


        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<ITeacherService, TeacherService>();

            return services;
        }

        public static IServiceCollection RegisterRespository(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Subject>, SubjectRepository>();
            services.AddTransient<IRepository<Class>, ClassRepository>();
            services.AddTransient<IRepository<Teacher>, TeacherRepository>();
            return services;
        }

        //public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        ////{
        ////    services.AddAutoMapper(typeof(CeATalkMapper));

        ////    return services;
        ////}

    }
}