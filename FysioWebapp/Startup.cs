using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using FysioWebapp.Helpers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FysioWebapp
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

            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Default")));

            services.AddScoped<IUserRepository, UserRepository>();


            services.AddControllersWithViews();
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
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseRouting();
            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("manage_route", "Manage/{controller=Dashboard}/{action=Index}/{id?}",
                    defaults: new { area = "Manage" }, constraints: new { area = "Manage" });

                endpoints.MapControllerRoute("patient_route", "Patient/{controller=Dashboard}/{action=Index}/{id?}",
                    defaults: new { area = "Patient" }, constraints: new { area = "Patient" });

                endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}/{id?}",
                    defaults: new { area = "Public" }, constraints: new { area = "Public" });

                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Login}/{action=Index}");
            });
        }
    }
}
