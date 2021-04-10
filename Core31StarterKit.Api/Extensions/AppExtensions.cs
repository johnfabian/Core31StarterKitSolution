using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core31StarterKit.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core31StarterKit.WebApi");
            });

        }


        public static void UseHealthChecksExtension(this IApplicationBuilder app)
        {
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/healthchecks-ui";
                options.ApiPath = "/health";
            });
           
        }

    }
}
