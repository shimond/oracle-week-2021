using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first_web_app.Contracts;
using first_web_app.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace first_web_app
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
            services.AddSingleton<IMoviesService, MoviesServiceMock>();
            //services.AddScoped
            //services.AddTransient

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "first_web_app", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseStaticFiles();
            //app.Use(async (context, middleware) => { 
            //    await context.Response.WriteAsync(" Mid 1A");
            //    await middleware();
            //    await context.Response.WriteAsync(" Mid 1B");
            //});

            //app.Use(async (context, middleware) => {
            //    await context.Response.WriteAsync(" Mid 2A ");
            //    await middleware();
            //    await context.Response.WriteAsync(" Mid 2B ");
            //});


            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Hello");
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "first_web_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
