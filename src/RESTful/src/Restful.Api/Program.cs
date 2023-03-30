using System.Text.Json.Serialization;
using Restful.Api.FakeData.Services;
using Restful.Api.Infrastructure.Extensions;
using Serilog;

namespace Restful.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.RegisterInfrastructureServices();

        var app = builder.Build();

        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<InMemoryDataInitializer>();

            await initializer.PopulateAsync();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}