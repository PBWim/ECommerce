// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "Program.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web
{
    using System;
    using DataAccess;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Get a DB context instance from the dependency injection container.
                    var context = services.GetRequiredService<ECommerceDBContext>();

                    // Call the seed method, passing to it the context.
                    DbInitializer.Initialize(context);                    
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
                // Dispose the context when the seed method completes.
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) // builder pattern creates a web application host (The WebHost.CreateDefaultBuilder method sets the content root to the current directory as the host root)
                .UseStartup<Startup>() // The UseStartup method on WebHostBuilder specifies the Startup class for your app
                .Build();
    }
}