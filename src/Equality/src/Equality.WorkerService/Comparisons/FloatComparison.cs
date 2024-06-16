namespace Equality.WorkerService.Comparisons;

public class FloatComparison : ComparisonAbstractBase
{
    public FloatComparison(ILogger<ComparisonAbstractBase> logger) : base(logger)
    {
    }

    public override void Run()
    {
        PrintToConsole(1.0000000000000000000m == 1.0000000000000000001m);
        PrintToConsole(1.0000000000f == 1.0000000001f);
        PrintToConsole(1.000000000f == 1.000000001f);
        PrintToConsole(1.00000000f == 1.00000001f);
        PrintToConsole(1.0000000f == 1.0000001f);
    }
}
