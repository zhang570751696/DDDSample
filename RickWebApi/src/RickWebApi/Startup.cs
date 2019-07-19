using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rick.DataAccess.MySql;
using Rick.DataAccess.Config;
using RickWebApi.Infrastructure.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace RickWebApi
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
            services.AddCors(option =>
            {
                option.AddPolicy("*", builder => builder
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowAnyOrigin()
                                                .AllowCredentials());
            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddMvc()
                .AddJsonOptions(options=>options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwagger(new Info {
                Title = "RickWeb API",
                Version = "V1",
                Description = "Sample .NET Core REST API CQRS implementation with raw SQL and DDD using Clean Architecture."
            });

            services.UseDataAccess().UseDataAccessConfig(Path.Combine(Directory.GetCurrentDirectory(), "Configurations"), true, xmlFiles: "DataBase.xml");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseCustomSwagger("/swagger/v1/swagger.json", "RickWeb API V1");
        }
    }
}
