using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MMC.Application.IRepositories;
using MMC.Application.Services;

using ParamsService.Application.Interfaces;
using ParamsService.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Auto mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //MediatR
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //Services Injection
            services.AddScoped<IUnitOfService, UnitOfService>();


             

            
            var Theme = services.BuildServiceProvider().GetService<IUnitOfService>();
 
            services.AddSingleton<RabbitMQServer>(new RabbitMQServer(Theme));
            services.AddSingleton<NotificationToParams>(new NotificationToParams(Theme));
            return services;
        }
    }
}
