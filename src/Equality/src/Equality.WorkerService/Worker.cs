using Equality.WorkerService.Comparisons;

namespace Equality.WorkerService;

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Worker> _logger;

    public Worker(IHostApplicationLifetime hostApplicationLifetime, IServiceProvider serviceProvider, ILogger<Worker> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Type markerType = typeof(ComparisonAbstractBase);
        List<Type> comparerClasses = markerType.Assembly.GetTypes().Where(t => t.IsAssignableTo(markerType) && t != markerType).ToList();

        foreach (Type? comparerClass in comparerClasses)
        {
            ComparisonAbstractBase comparer = (ComparisonAbstractBase)ActivatorUtilities.CreateInstance(_serviceProvider, comparerClass);

            comparer.Run();
        }

        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }
}
