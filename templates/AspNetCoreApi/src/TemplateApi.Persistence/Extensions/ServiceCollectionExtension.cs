using Microsoft.Extensions.DependencyInjection;

namespace TemplateApi.Persistence.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterPersistence(this IServiceCollection services)
    {

        return services;
    }
}