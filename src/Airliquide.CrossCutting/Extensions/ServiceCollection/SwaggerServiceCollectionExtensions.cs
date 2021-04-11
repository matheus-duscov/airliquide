using AirLiquide.Resources.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Airliquide.CrossCutting.Extensions.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddAirliquideApiSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = SwaggerSettingsConstants.Title,
                        Version = SwaggerSettingsConstants.Version,
                        Description = SwaggerSettingsConstants.Description
                    });

                //var xmlApiFile = "Airliquide.Api.xml";
                var xmlContractsFile = "Airliquide.Contracts.xml";

                //var xmlPathForApi = Path.Combine(AppContext.BaseDirectory, xmlApiFile);
                var xmlPathForContracts = Path.Combine(AppContext.BaseDirectory, xmlContractsFile);

                //cfg.IncludeXmlComments(xmlApiFile);
                cfg.IncludeXmlComments(xmlContractsFile);
            });
        }
    }
}
