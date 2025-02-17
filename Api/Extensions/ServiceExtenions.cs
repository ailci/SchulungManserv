namespace Api.Extensions;

public static class ServiceExtenions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddControllers(); //WebApi

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        return services;
    }
    
    public static IServiceCollection ConfigureDb(this IServiceCollection services)
    {
        

        return services;
    }


}