using Core31StarterKit.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31StarterKit.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: dbcontext 

            //TODO: shared services

            //swagger
            services.AddSwaggerExtension();

            //controllers
            services.AddControllers();

            //versioning
            services.AddVersioningExtension();

            //healthchecks
            services.AddHealthChecksExtension();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //error hanndling page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //https redirect (uncomment to enable)
            //app.UseHttpsRedirection();

            //routing
            app.UseRouting();

            //TODO: authentication

            //authorization (uncomment to enable)
            //app.UseAuthorization();

            //swagger
            app.UseSwaggerExtension();

            //TODO: Add Error Handling

            //healthchecks
            app.UseHealthChecksExtension();
           

            //controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
