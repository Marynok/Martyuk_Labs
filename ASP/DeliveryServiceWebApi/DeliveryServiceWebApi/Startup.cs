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
using BL = DeliveryService.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            services.AddTransient<DbContext, DataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFoodController, BL.FoodController>();
            services.AddTransient<IManufacturerController, BL.ManufacturerController>();
            services.AddTransient<IFoodTypeController, BL.FoodTypeController>();

            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            services.AddMvc();
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

            _ = app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();

                  endpoints.MapControllerRoute("Create", "mvc/Food/Create", new { controller = "FoodMvc", action = "Create" });
                  endpoints.MapControllerRoute("Edit", "mvc/Food/Edit/{id}", new { controller = "FoodMvc", action = "Edit" });
                  endpoints.MapControllerRoute("Delete", "mvc/Food/Delete/{id}", new { controller = "FoodMvc", action = "Delete" });
                  endpoints.MapControllerRoute("Details", "mvc/Food/Details/{id}", new { controller = "FoodMvc", action = "Details" });
                  endpoints.MapControllerRoute("Index", "mvc/Food/Index", new { controller = "FoodMvc", action = "Index" });

                  endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=FoodMvc}/{action=Index}/{id?}");
              });

        }
    }
}
