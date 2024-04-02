using EventService.Application.IRepositories;
using EventService.Infrastructure.Data;
using EventService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure
{

    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //database setup




            string? con = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext,ApplicationDbContext>(options => options.UseSqlServer(con));



            //dependency injection contanaire
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
