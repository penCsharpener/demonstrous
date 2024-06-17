using Serilog;
using Template.WrkSrvc.WorkerService.Models;

namespace Template.WrkSrvc.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSerilog((services, loggerConfig) =>
        {
            loggerConfig.ReadFrom.Configuration(builder.Configuration);
        });
        builder.Services.AddSingleton(() =>
        {
            AppSettings? appsettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            return appsettings;
        });
#if UseWindowsHosting
        builder.Services.AddWindowsService();
#endif
        builder.Services.AddHostedService<Worker>();

        IHost host = builder.Build();
        host.Run();
    }
}