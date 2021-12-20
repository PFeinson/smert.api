using smert.Settings;
using Google.Cloud.Diagnostics.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.IO;
using System.Text;

namespace smert
{
    public class Program
    {
        public static AppSettings AppSettings { get; private set; }

        public static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var enc1252 = System.Text.Encoding.GetEncoding(1252);
            // Create Database table if it does not exist.
            //StartupExtensions.InitializeDatabase();
            BuildWebHost(args).Build().Run();
        }

        
        public static IWebHostBuilder BuildWebHost(string[] args)
        {
            ReadAppSettings();
            return WebHost.CreateDefaultBuilder(args)
                .UseGoogleDiagnostics(
                    AppSettings.GoogleCloudSettings.ProjectId,
                    AppSettings.GoogleCloudSettings.ServiceName,
                    AppSettings.GoogleCloudSettings.Version)
                .UseStartup<Startup>()
                .UsePortEnvironmentVariable();
        }

        /// <summary>
        /// Read application settings from appsettings.json. 
        /// </summary>
        private static void ReadAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Read json config into AppSettings.
            AppSettings = new AppSettings();
            config.Bind(AppSettings);
        }
    }

    static class ProgramExtensions
    {
        // Google Cloud Run sets the PORT environment variable to tell this
        // process which port to listen to.
        public static IWebHostBuilder UsePortEnvironmentVariable(
            this IWebHostBuilder builder)
        {
            string port = Environment.GetEnvironmentVariable("PORT");
            if (!string.IsNullOrEmpty(port))
            {
                builder.UseUrls($"http://0.0.0.0:{port}");
            }
            return builder;
        }
    }
}