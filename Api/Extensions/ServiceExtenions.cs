using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contracts;
using Persistence.Repositories;
using Services;

namespace Api.Extensions;

public static class ServiceExtenions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddControllers(); //WebApi

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        //Automapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //GlobalExceptionHandler
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
    
    public static IServiceCollection ConfigureDb(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<QotdContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        return services;
    }


    public static IServiceCollection ConfigureRepo(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        return services;
    } 
    
    public static IServiceCollection ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();

        return services;
    }

}