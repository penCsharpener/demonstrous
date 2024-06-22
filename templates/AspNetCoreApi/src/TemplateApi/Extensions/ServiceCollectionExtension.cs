using TemplateApi.Application.Extensions;

namespace TemplateApi.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.RegisterApplication();

        return services;
    }
}
