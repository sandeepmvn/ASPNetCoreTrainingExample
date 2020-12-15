using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MVCWebApplication.CustomMiddlewares;
using MVCWebApplication.EFModels;
using MVCWebApplication.Models;
using MVCWebApplication.Repositories;
using MVCWebApplication.Services;
using MVCWebApplication.Utility;

namespace MVCWebApplication
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
            //services.Add(new ServiceDescriptor(typeof(IMyDepedencyService), typeof(MyDepedencyService), ServiceLifetime.Singleton));
            services.AddScoped<IMyDepedencyService, MyDepedencyService>();
            services.AddControllersWithViews(x => x.CacheProfiles.Add("publiccache",
                new Microsoft.AspNetCore.Mvc.CacheProfile()
                {
                    Duration = 40,
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any,
                    NoStore = false
                }));
            services.Configure<Helper>(Configuration);
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.Name = ".AspNet.Session";
                options.Cookie.HttpOnly = true;
            });

            services.AddDbContext<SampleCoreDBContext>(x =>
            {
                x.UseSqlServer(this.Configuration.GetConnectionString("Default"));
            });

            services.AddDbContext<EmployeeDBContext>(x => {
                x.UseSqlServer(this.Configuration.GetConnectionString("Default2"));
            });

            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
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
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/Home/Page{0}");
            //app.UseStaticFiles(new StaticFileOptions() {
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "mystaticfiles")),
            //});

            app.UseStatusCodePages(async context =>
            {
                //context.HttpContext.Response.ContentType = "text/plain";
                //await context.HttpContext.Response.WriteAsync(
                //"Status code page, status code: " +
                //context.HttpContext.Response.StatusCode);
                Console.WriteLine(context.HttpContext.Response.StatusCode);
            });


            //app.UseLogURL("Req:");

            //app.USeLOgURLMiddelware()
            //app.UseMiddleware(typeof(LogURLMiddleware),"Request:: ");
            //app.Run(requesthandler);
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine(context.Request.Path);
            //    Console.WriteLine("Request Logic from Middleware 1");
            //    await next();
            //    Console.WriteLine("Respone Logic from middleware 2");
            //});

            //app.Map("/Home", (app1) =>
            //{
            //    app1.Use(async (context, next) =>
            //    {

            //    });
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllersRoute("","cacheex/action/{name}")
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private void mapcustomMiddleware(IApplicationBuilder obj)
        //{
        //    obj.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("this is from map middleware");
        //    });
        //}

        //private async Task requesthandler(HttpContext context)
        //{
        //    Console.WriteLine("this is run method");

        //    await Task.CompletedTask;
        //}
    }
}
