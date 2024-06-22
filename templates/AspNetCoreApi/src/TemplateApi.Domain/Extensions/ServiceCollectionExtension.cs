using Microsoft.Extensions.DependencyInjection;

namespace TemplateApi.Domain.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterDomain(this IServiceCollection services)
    {

        return services;
    }
}
