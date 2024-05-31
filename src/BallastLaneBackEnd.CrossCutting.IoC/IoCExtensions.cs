//using BallastLaneBackEnd.Application;
//using BallastLaneBackEnd.Domain.Entities;
//using BallastLaneBackEnd.Domain.Interfaces.Services;
//using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BallastLaneBackEnd.CrossCutting.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            //  services.RegisterAutoMapper();
            services.RegisterServices();

            return services;
        }


        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
        //    services.AddTransient<IStudentService, StudentService>();
         

            return services;
        }

        //public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        ////{
        ////    services.AddAutoMapper(typeof(CeATalkMapper));

        ////    return services;
        ////}

    }
}