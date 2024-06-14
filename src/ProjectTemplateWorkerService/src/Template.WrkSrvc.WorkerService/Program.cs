namespace Template.WrkSrvc.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
#if UseWindowsHosting
        builder.Services.AddWindowsService();
#endif
        builder.Services.AddHostedService<Worker>();

        IHost host = builder.Build();
        host.Run();
    }
}