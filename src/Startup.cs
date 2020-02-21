using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using netCoreWorkshop.Business;
using Microsoft.EntityFrameworkCore;
using netCoreWorkshop.Middlewares;


namespace netCoreWorkshop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var startupLogger = loggerFactory.CreateLogger<Startup>();
            //app.UseAPIKey();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            
            app.UseDeveloperExceptionPage();
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<ICarService, CarService>();
            services.AddDbContext<Data.DBContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Articles"));
            });

            // Setup options with DI
            services.AddOptions();
            services.Configure<APIKeyOptions>(Configuration.GetSection("APIKeyOptions"));
        }
    }
}

