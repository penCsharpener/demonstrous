using Microsoft.Extensions.DependencyInjection;
using Restful.Api.Application.Abstractions;
using Restful.Api.FakeData.Services;

namespace Restful.Api.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFakeDataProvider, FakeDataProvider>();

        return services;
    }
}