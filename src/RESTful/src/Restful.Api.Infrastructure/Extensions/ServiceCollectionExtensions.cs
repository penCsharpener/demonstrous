using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restful.Api.Application.Abstractions;
using Restful.Api.Context;
using Restful.Api.FakeData.Services;

namespace Restful.Api.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDbContext"));

        services.AddScoped<IFakeDataProvider, FakeDataProvider>();
        services.AddScoped<InMemoryDataInitializer>();

        return services;
    }
}