using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistance;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
                        });
            services.AddDbContext<DataContext>(options =>
           {
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
           });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(c =>
           {
               c.AddPolicy("AllowSpecificOrigin",
               options => options.AllowAnyHeader().AllowAnyMethod().
               WithOrigins("http://localhost:3000"));
           });
            return services;
        }
    }
}