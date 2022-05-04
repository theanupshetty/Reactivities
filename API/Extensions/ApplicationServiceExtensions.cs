using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(options =>
           {
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
           });
            return services;
        }
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(c =>
           {
               c.AddPolicy("AllowSpecificOrigin",
               options => options.AllowAnyHeader().AllowAnyMethod().
               WithOrigins("https://localhost:4200"));
           });
            return services;
        }
    }
}