using Microsoft.Extensions.DependencyInjection;

namespace TemplateApi.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {

        return services;
    }
}
