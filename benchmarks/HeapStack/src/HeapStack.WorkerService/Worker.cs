namespace HeapStack.WorkerService;

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<Worker> _logger;

    public Worker(IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }

        _hostApplicationLifetime.StopApplication();
    }
}
