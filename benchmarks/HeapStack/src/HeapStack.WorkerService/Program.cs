using HeapStack.WorkerService.Models;
using Serilog;

namespace HeapStack.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSerilog((services, loggerConfig) =>
        {
            loggerConfig.ReadFrom.Configuration(builder.Configuration);
        });
        builder.Services.AddSingleton(() =>
        {
            var appsettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            return appsettings;
        });
        builder.Services.AddWindowsService();
        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}