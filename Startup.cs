// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
// Json
using Newtonsoft.Json;
// MySql
using MySql;
using MySql.Data.MySqlClient;
// ASP.Net core
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
// Microsoft Extensions
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions;
// OpenAPI
using Microsoft.OpenApi.Models;
// AutoMapper
using AutoMapper;
// Google Cloud
using Google.Cloud.SecretManager;
// smert
using smert.Services;
using smert.Repositories;
using smert.Configuration;
using smert.Models;
using smert.Models.DTO;



namespace smert
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
            // Register Services
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll", 
                    builder =>
                    {
                            builder
                            .WithOrigins("*")
                            .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS")
                            .Build();
                    }
                    
                );  
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "smert", Version = "v1" });
            });
            services.AddResponseCaching();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "smert v1"));
            }
            app.UseCors("CorsAllowAll");
            
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
