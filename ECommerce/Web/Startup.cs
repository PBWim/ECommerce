// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "Startup.cs" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Web
{
    using BusinessService.Mapper.Admin;
    using BusinessService.Mapper.Contract.Admin;
    using BusinessService.Service.Admin;
    using BusinessService.Service.Contract.Admin;
    using DataAccess;
    using DataAccess.Repository.Admin;
    using DataAccess.Repository.Contract.Admin;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Web.AppSettings;

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
            services.AddMvc();

            services.Configure<AppSettingsModel>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<ECommerceDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ECommerceDBConnection")));

            AddTransient(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Static files, such as HTML, CSS, images, and JavaScript, are assets an 
            // ASP.NET Core app serves directly to clients. 
            // Some configuration is required to enable to serving of these files.
            // Eg : In wwwroot/css, images, js
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areaRoute",
                 template: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            MigrateDatabase(app);
        }

        private void MigrateDatabase(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var identityContext = serviceScope.ServiceProvider.GetRequiredService<ECommerceDBContext>();
                identityContext.Database.Migrate();
            }
        }

        private void AddTransient(IServiceCollection services)
        {
            // Registering services in DI container
            // Eg : everytime you request a type of IAdminService, you'll get a new instance of the AdminService
            services.AddTransient<IAdminModelMapper, AdminModelMapper>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<Areas.Admin.Mappers.Contracts.Admin.IAdminModelMapper, Areas.Admin.Mappers.Admin.AdminModelMapper>();
        }
    }
}