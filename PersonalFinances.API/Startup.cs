using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.DataAccess.Repositories;
using System;
using PersonalFinances.Application.AutoMapper;
using PersonalFinances.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using PersonalFinances.Application.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace PersonalFinances.API
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
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=PersonalReleaseDB;Trusted_Connection=True;";
            services.AddDbContext<PersonalFinancesContext>(options => options.UseSqlServer(connectionString));

            services.AddAutoMapper(typeof(ReleaseToReleaseViewModelMappingProfile), typeof(ReleaseViewModelToReleaseMappingProfile));

            services.AddScoped<IPersonalFinanceRepository, PersonalFinanceRepository>();

            services.AddScoped<IReleaseAppService, ReleaseAppService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                // API Informations
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalFinancesAPI", Version = "v1" });

                // Enables swagger to obtain methods Summary
                var apiXMLFile = $"{ Assembly.GetExecutingAssembly().GetName().Name }.xml";
                var apiXMLPath = Path.Combine(AppContext.BaseDirectory, apiXMLFile);
                c.IncludeXmlComments(apiXMLPath);
            });
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

            // Enable Swagger on API
            app.UseSwagger();

            // Enable Swagger UI on API
            app.UseSwaggerUI(o => 
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal Finances API V1");
            });
        }
    }
}
