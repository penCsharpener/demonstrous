using Serilog;

namespace Generics.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddSerilog((services, lc) =>
        {
            lc.ReadFrom.Configuration(builder.Configuration);
        });
        builder.Services.AddWindowsService();
        builder.Services.AddHostedService<Worker>();

        IHost host = builder.Build();
        host.Run();
    }
}