using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace OpenSearchSock.Infrastructure.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Blog",
                Description = "ASP.NET Core C# Vertical Slice Architecture, CQRS, REST API, DDD, SOLID Principles"
            });

            

            swaggerOptions.ResolveConflictingActions(apiDescription => apiDescription.FirstOrDefault());

           
        });
    }
 
}
