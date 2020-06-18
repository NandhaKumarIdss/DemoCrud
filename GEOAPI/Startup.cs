using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using GeoApplication.Intefaces;
using GeoApplication.Mapping;
using GeoApplication.Model;
using GeoApplication.Services;
using GeoApplication.Validation;
using GeoData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GEOAPI
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
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CountryValidation>());
                    //.AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<StateValidation>())
                    //.AddFluentValidation(i => i.RegisterValidatorsFromAssemblyContaining<CityValidation>());
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddAutoMapper(typeof(UserCountryModel));
            services.AddAutoMapper(typeof(CityUserModel));
            services.AddAutoMapper(typeof(StateUserModel));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Geo",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API" });
            });
           
            services.AddDbContext<GeoDBContext>(option => option.UseSqlServer(Configuration["ConnectionStrings:connectionstring"]));


            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "Geo/dist";
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    );
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geo V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Countries}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Geo";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
