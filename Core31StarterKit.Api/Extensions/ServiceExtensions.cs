using Core31StarterKit.Api.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31StarterKit.Api.Extensions
{
    public static class ServiceExtensions
    {
        
        public static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = configuration.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();

            services.AddSwaggerGen(c =>
            {
                //simple configuration, add auth if using tokens            
                c.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo
                {
                    Version = swaggerSettings.Version,
                    Title = swaggerSettings.Title
                });
            });
        }


        public static void AddVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);

                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;

                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }


        public static void AddHealthChecksExtension(this IServiceCollection services)
        {
            services.AddHealthChecks();

            //TODO: configure other storage providers such as sql
            services.AddHealthChecksUI().AddInMemoryStorage();

        }        


    }
}
