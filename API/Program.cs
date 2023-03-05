using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>(); 

           try
           {
               var context = services.GetRequiredService<DataContext>();
               await context.Database.MigrateAsync();
               await Seed.SeedUsers(context);

           }
           catch (Exception ex)
           {
              var logger = loggerFactory.CreateLogger<Program>();
              logger.LogError(ex, "An error occured while seeding the DB");
           }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
