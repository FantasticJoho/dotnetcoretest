using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using dotnetcoretest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;

namespace dotnetcoretest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            using (var client = new TicketingContext())
            {
                client.Database.EnsureCreated();
            }
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // Add framework services.
            services.AddMvc();
            services.AddEntityFrameworkSqlite().AddDbContext<Models.TicketingContext>();
               services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", 
        new Info 
        {
             Title = "Custom API", 
             Version = "v1", 
               Description = "A simple example ASP.NET Core Web API",
        TermsOfService = "None",
        Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Jonathan Honoré", Email = "", Url = "https://twitter.com/fantasticJoho"},
        License = new License { Name = "No licence yet", Url = "http://google.com" }
              });
    });
 
      
    
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }
    }
}
