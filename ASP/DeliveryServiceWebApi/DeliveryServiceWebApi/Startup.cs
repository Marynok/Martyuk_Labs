using DeliveryService.Interfaces;
using DeliveryServiceEF.Data;
using DeliveryServiceEF.Data.DataWorkers;
using DeliveryServiceEF.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DeliveryService.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceWebApi.ViewModels.ViewModelHelpers;
using DeliveryServiceWebApi.Filters;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using DeliveryServiceWebApi.ViewModels.ViewModelHelpers.Interfaces;

namespace DeliveryServiceWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext, DataContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IFoodTypeService, FoodTypeService>();
            services.AddTransient<IFoodMapper,FoodMapper>();


            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            services.AddScoped<FoodExceptionFilter>();
     
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryServiceWebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryServiceWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

           
            _ = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "mvcFoodRoute",
                   pattern: "mvc/Food/{action}/{id:int?}",
                   defaults: new { Controller="FoodMvc"});

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=FoodMvc}/{action=Index}");
            });
        }
    }
}
