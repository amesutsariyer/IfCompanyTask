using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfCompany.Interface.Business;
using IfCompany.Interface.Repository;
using IfCompanyTask.API.Configuration;
using IfCompanyTask.Business.BusinessService;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.DataContext;
using IfCompanyTask.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace IfCompanyTask.API
{
    public class Startup
    {
        readonly IHostingEnvironment HostingEnvironment;
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            HostingEnvironment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Also make top level configuration available (for EF configuration and access to connection string)
            services.AddSingleton(Configuration);
            //IConfigurationRoot
            services.AddSingleton<IConfiguration>(Configuration);

            //Add Support for strongly typed Configuration and map to class
            services.AddOptions();
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

            //Set database.
            if (Configuration["AppConfig:UseInMemoryDatabase"] == "true")
            {
                services.AddDbContext<IfDataContext>(opt => opt.UseInMemoryDatabase("IfDbMemory"));
            }
            else
            {
                services.AddDbContext<IfDataContext>(c =>
                    c.UseSqlServer(Configuration.GetConnectionString("IfCompanyDbConnection")));
            }

            //Cors policy is added to controllers via [EnableCors("CorsPolicy")]
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            //Instance injection
            //  services.AddScoped(typeof(IAutoMapConverter<,>), typeof(AutoMapConverter<,>));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IIFRepository<>), typeof(IfRepository<>));
            services.AddScoped<IRiskRepository, RiskRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IRiskBusiness, RiskBusiness>();
            services.AddScoped<IPolicyBusiness, PolicyBusiness>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "IF Company Task Services version 1.0",
                    Description = "If Company Task Project API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Ahmet Mesut Sarıyer",
                        Email = "ahmetmesutsariyer@gmail.com",
                        Url = "https://github.com/amesutsariyer"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://github.com/amesutsariyer"
                    }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            // Serilog config
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(pathFormat: "logs\\log-{Date}.log")
                    .CreateLogger();
            app.UseDatabaseErrorPage();
            app.UseStatusCodePages();
            //Apply CORS.
            app.UseCors("CorsPolicy");

            //put last so header configs like CORS or Cookies etc can fire
            app.UseMvcWithDefaultRoute();

            app.UseDefaultFiles();
            //Serve files inside of web root
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "If Company");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
