using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMC.Application.IRepositories;
using MMC.Infrastructure.Repositories;
using ParamsService.Application.Interfaces;
using ParamsService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsService.Infrastructure
{
    public  static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //database setup
           
             services.AddDbContext<MMC_Params>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //dependency injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
