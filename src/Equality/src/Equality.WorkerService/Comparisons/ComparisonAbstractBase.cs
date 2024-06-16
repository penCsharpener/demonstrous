using System.Runtime.CompilerServices;

namespace Equality.WorkerService.Comparisons;

public abstract class ComparisonAbstractBase
{
    private readonly ILogger<ComparisonAbstractBase> _logger;

    protected ComparisonAbstractBase(ILogger<ComparisonAbstractBase> logger)
    {
        _logger = logger;
    }

    public abstract void Run();

    protected void PrintToConsole<T>(T value, [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        _logger.LogInformation("{expression}: {value}", expression, value);
    }
}
