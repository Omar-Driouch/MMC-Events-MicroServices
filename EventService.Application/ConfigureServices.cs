using EventService.Application.Interfaces;
using EventService.Application.Mapping;
using EventService.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Application
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
            //Broker Injection
            var AlltheServices = services.BuildServiceProvider().GetService<IUnitOfService>();

            services.AddSingleton<RabbitMQServer>(new RabbitMQServer(AlltheServices));
            
            return services;
        }
    }
}
