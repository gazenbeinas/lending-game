using System.Reflection;
using AutoMapper;
using LendingGame.Application.ViewModels;
using LendingGame.Data.Context;
using LendingGame.Infra.Bootstrap;
using LendingGame.Infra.Identity.Data;
using LendingGame.Infra.Identity.Models;
using LendingGame.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LendingGame.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IoC.SetServiceCollection(services);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<LendingGameContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("LendingGame.Data"));
            }, ServiceLifetime.Transient);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddAutoMapper(typeof(MapperProfile)
                .GetTypeInfo().Assembly);

            RegisterDependencyModules.Register();

            IoC.SetContainer(services.BuildServiceProvider());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "application",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    "api",
                    "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}