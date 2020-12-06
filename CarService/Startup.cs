using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Database;
using CarService.Models;
using CarService.Repositories;
using CarService.Services.Implementation;
using CarService.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CarService
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
            services.AddMvc();

            services.AddTransient<IRepairService, RepairService>();
            services.AddTransient<IBaseRepository<Document>, BaseRepository<Document>>();
            services.AddTransient<IBaseRepository<Car>, BaseRepository<Car>>();
            services.AddTransient<IBaseRepository<Worker>, BaseRepository<Worker>>();

            services.AddDbContext<ApplicationContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


            services.AddSwaggerGen();

            //services.AddSwaggerGen(oprions =>
            //{
            //    oprions.SwaggerDoc("v1",
            //       new OpenApiInfo
            //       {
            //           Title = "Swagger CarService",
            //           Description = "Swagger for CarService",
            //           Version = "v1"
            //       });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("swagger/v1/swagger.json", "Swagger CarService");
            //});
        }
    }
}
