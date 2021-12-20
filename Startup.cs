using System.Reflection;
using System.Data;
using System.Data.Common;
// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Polly;
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
using Google.Cloud.Diagnostics.AspNetCore;
// smert
using smert.Services;
using smert.Repositories;
using smert.Configuration;
using smert.Models;
using smert.Models.DTO;
using smert.Filters;
using smert.Settings;



namespace smert
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            // Register Services
            services.AddSingleton(sp => StartupExtensions.GetMySqlConnectionString());
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
            services.AddMvc( options =>
                {
                    options.Filters.Add(typeof(DbExceptionFilterAttribute));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(options => 
                {    
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "smert v1");
                    options.RoutePrefix = string.Empty;
                });
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

    static class StartupExtensions
    {
        public static void OpenWithRetry(this DbConnection connection) =>
            // [START cloud_sql_mysql_dotnet_ado_backoff]
            Policy
                .Handle<MySqlException>()
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(5)
                })
                .Execute(() => connection.Open());
            // [END cloud_sql_mysql_dotnet_ado_backoff]
        public static MySqlConnectionStringBuilder GetMySqlConnectionString()
        {
            MySqlConnectionStringBuilder connectionString; 
            if (Environment.GetEnvironmentVariable("DB_HOST") != null)
            {
                connectionString = NewMysqlTCPConnectionString();
            }
            else
            {
                connectionString = NewMysqlUnixSocketConnectionString();
            }
            // The values set here are for demonstration purposes only. You 
            // should set these values to what works best for your application.
            // [START cloud_sql_mysql_dotnet_ado_limit]
            // MaximumPoolSize sets maximum number of connections allowed in the pool.
            connectionString.MaximumPoolSize = 5;
            // MinimumPoolSize sets the minimum number of connections in the pool.
            connectionString.MinimumPoolSize = 0;
            // [END cloud_sql_mysql_dotnet_ado_limit]
            // [START cloud_sql_mysql_dotnet_ado_timeout]
            // ConnectionTimeout sets the time to wait (in seconds) while
            // trying to establish a connection before terminating the attempt.
            connectionString.ConnectionTimeout = 15;
            // [END cloud_sql_mysql_dotnet_ado_timeout]
            // [START cloud_sql_mysql_dotnet_ado_lifetime]
            // ConnectionLifeTime sets the lifetime of a pooled connection
            // (in seconds) that a connection lives before it is destroyed
            // and recreated. Connections that are returned to the pool are
            // destroyed if it's been more than the number of seconds
            // specified by ConnectionLifeTime since the connection was
            // created. The default value is zero (0) which means the
            // connection always returns to pool.
            connectionString.ConnectionLifeTime = 1800; // 30 minutes
            // [END cloud_sql_mysql_dotnet_ado_lifetime]
            return connectionString;
        }

        public static MySqlConnectionStringBuilder NewMysqlTCPConnectionString()
        {
            // [START cloud_sql_mysql_dotnet_ado_connection_tcp]
            // Equivalent connection string:
            // "Uid=<DB_USER>;Pwd=<DB_PASS>;Host=<DB_HOST>;Database=<DB_NAME>;"
            var connectionString = new MySqlConnectionStringBuilder()
            {
                // The Cloud SQL proxy provides encryption between the proxy and instance.
                SslEnable = true,
                SslMode = MySqlSslMode.Required,

                // Remember - storing secrets in plain text is potentially unsafe. Consider using
                // something like https://cloud.google.com/secret-manager/docs/overview to help keep
                // secrets secret.
                Server = Environment.GetEnvironmentVariable("DB_HOST"),   // e.g. '127.0.0.1'
                // Set Host to 'cloudsql' when deploying to App Engine Flexible environment
                UserID = Environment.GetEnvironmentVariable("DB_USER"),   // e.g. 'my-db-user'
                Password = Environment.GetEnvironmentVariable("DB_PASS"), // e.g. 'my-db-password'
                Database = Environment.GetEnvironmentVariable("DB_NAME"), // e.g. 'my-database'
            };
            connectionString.Pooling = true;
            // Specify additional properties here.
            return connectionString;
            // [END cloud_sql_mysql_dotnet_ado_connection_tcp]
        }

        public static MySqlConnectionStringBuilder NewMysqlUnixSocketConnectionString()
        {
            // [START cloud_sql_mysql_dotnet_ado_connection_socket]
            // Equivalent connection string:
            // "Server=<dbSocketDir>/<INSTANCE_CONNECTION_NAME>;Uid=<DB_USER>;Pwd=<DB_PASS>;Database=<DB_NAME>;Protocol=unix"
            String dbSocketDir = Environment.GetEnvironmentVariable("DB_SOCKET_PATH") ?? "/cloudsql";
            String instanceConnectionName = Environment.GetEnvironmentVariable("INSTANCE_CONNECTION_NAME");
            var connectionString = new MySqlConnectionStringBuilder()
            {
                SslEnable = true,
                // The Cloud SQL proxy provides encryption between the proxy and instance.
                SslMode = MySqlSslMode.Required,
                // Remember - storing secrets in plain text is potentially unsafe. Consider using
                // something like https://cloud.google.com/secret-manager/docs/overview to help keep
                // secrets secret.
                Server = String.Format("{0}/{1}", dbSocketDir, instanceConnectionName),
                UserID = Environment.GetEnvironmentVariable("DB_USER"),   // e.g. 'my-db-user
                Password = Environment.GetEnvironmentVariable("DB_PASS"), // e.g. 'my-db-password'
                Database = Environment.GetEnvironmentVariable("DB_NAME"), // e.g. 'my-database'
                ConnectionProtocol = MySqlConnectionProtocol.UnixSocket
            };
            connectionString.Pooling = true;
            // Specify additional properties here.
            return connectionString;
            // [END cloud_sql_mysql_dotnet_ado_connection_socket]
        }
    }

}
