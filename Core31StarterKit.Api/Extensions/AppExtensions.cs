using Core31StarterKit.Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core31StarterKit.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerSettings = configuration.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerSettings.Url, swaggerSettings.Title);
            });

        }


        public static void UseHealthChecksExtension(this IApplicationBuilder app, IConfiguration configuration)
        {
            var healthCheckSettings = configuration.GetSection(nameof(HealthCheckSettings)).Get<HealthCheckSettings>();

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = healthCheckSettings.UIPath;
                options.ApiPath = healthCheckSettings.ApiPath;
            });           
        }

    }
}
