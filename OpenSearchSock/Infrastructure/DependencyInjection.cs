using OpenSearchSock.Common.Interfaces;
using OpenSearchSock.Domain.Models;
using OpenSearchSock.Infrastructure.Data;
using OpenSearchSock.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace OpenSearchSock.Infrastructure;

public static class DependencyInjection
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
            var db = context.CreateDbContext();
            db.SeedSampleData();


        }
        catch (Exception ex)
        {

        }

        return app;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      //  services.AddSingleton<IProductRepository, ProductRepository>();
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (!configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(databaseName:$"{Guid.NewGuid()}_SockDb"));
        }
        else
        {
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
        services.AddControllers();
        return services;
    }


}
