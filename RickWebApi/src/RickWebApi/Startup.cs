using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rick.DataAccess.MySql;
using Rick.DataAccess.Config;
using RickWebApi.Infrastructure.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json.Serialization;
using MediatR;
using System.Reflection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using RickWebApi.Moudles;
using CommonServiceLocator;
using Autofac.Extras.CommonServiceLocator;

namespace RickWebApi
{
    /// <summary>
    /// User Startup
    /// </summary>
    public class Startup
    {
        private static readonly string CurrentDoretory = Directory.GetCurrentDirectory();
        private static readonly string ConfDirectory = Path.Combine(CurrentDoretory, "Configurations");

        private readonly IHostingEnvironment Env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
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
                .AddJsonOptions(options =>
                {
                    // Make Json data field name Pascal Case
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // Igore null value
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

                    // Use MicrosoftDateFormat : /Date(1521479839707+0800)/
                    // ISODateFormat : 2018-03-20T01:17:19.707+0800
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwagger(new Info
            {
                Title = "RickWeb API",
                Version = "V1",
                Description = "Sample .NET Core REST API CQRS implementation with raw SQL and DDD using Clean Architecture."
            });

            services.UseDataAccess()
                .UseDataAccessConfig(ConfDirectory, true, null, "command.xml", $"database.{Env.EnvironmentName.ToLower()}.xml");

            return CreateAutofacServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //     app.UseDeveloperExceptionPage();
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

        private IServiceProvider CreateAutofacServiceProvider(IServiceCollection services)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            container.RegisterModule(new EmailMoudle());

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));

            return new AutofacServiceProvider(buildContainer);
        }
    }
}
