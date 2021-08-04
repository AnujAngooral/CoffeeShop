using Api.GlobalException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using services;
using services.Impl;
using services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api
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
            services.AddControllers();
            Registration.ConfigureServices(services);
            services.AddSwaggerGen(c=> {
                //c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                //{
                //    Title = "My APIs",
                //    Version = "v1.0",
                //    Description = "REST APIs "
                //});


                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                c.IncludeXmlComments(xmlpath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string baseApiUrl = Configuration.GetSection("BaseApiUrl").Value;
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Hook in the global error-handling middleware
            app.UseSwaggerUI(c =>
            {
                // For Debug in Kestrel
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
             
                // To deploy on IIS
             //    c.SwaggerEndpoint("" + baseApiUrl + "/swagger/v1/swagger.json", "My API V1");
               // c.SwaggerEndpoint("../swagger/v1/swagger.json", "MyAPI V1");

            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
