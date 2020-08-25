using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAspNetSite.Models;
namespace TestAspNetSite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Cookie")
                .AddCookie("Cookie",opt =>
            {
                opt.LoginPath = "/Account/Login";
            });
            services.AddAuthorization();
            services.AddTransient<IProductRepository,EFProductRepository>();
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]).EnableSensitiveDataLogging()
            );  
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(end =>
            {
                end.MapDefaultControllerRoute();
            });
            SeedData.EnsurePopulated(app);
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}",
            //        defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
