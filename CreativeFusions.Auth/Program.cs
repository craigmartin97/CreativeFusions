using CreativeFusions.Auth.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CreativeFusions.Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                // Get service provider
                IServiceProvider services = scope.ServiceProvider;

                // Get database and migrate
                CreativeFusionsDbContext dbContext = services.GetRequiredService<CreativeFusionsDbContext>();
                dbContext.Database.Migrate();

                // Seed database with test data
                AccountDbInitializer.SeedDatabase(services);
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
