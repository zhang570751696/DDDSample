using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RickWebApi.Infrastructure.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services, Info info)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", info);

                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlFiles = Directory.GetFiles(basePath, "*.xml", SearchOption.TopDirectoryOnly);
                if (xmlFiles != null)
                {
                    foreach (var xmlFile in xmlFiles)
                    {
                        options.IncludeXmlComments(xmlFile, true);
                    }
                }
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, string swaggerUrl, string swaggerName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerUrl, swaggerName);
            });
        }
    }
}
