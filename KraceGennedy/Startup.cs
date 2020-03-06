using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KraceGennedy.Models;
using KraceGennedy.Data;
using Microsoft.AspNetCore.Identity;
using KraceGennedy.Interfaces;
using KraceGennedy.ApiClients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace KraceGennedy
{
    public class Startup
    {
        //private IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddDbContextPool<DbContext>(options =>
            //options.UseSqlserver(Configuration.GetConnectionString("KGConnection")));

            //database connection string
            var connStr = Configuration.GetConnectionString("KGConnection");
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });
            services.AddDbContext<KraceGennedyContext>(options =>
                options.UseSqlServer(connStr));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<KraceGennedyContext>();
            services.AddScoped<IWeatherInterface, WeatherClient>();
            services.AddScoped<IWeatherRepositoryInterface, WeatherRepository>();
            services.AddScoped<IUserRepositoriesInterface, UserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
}
