using Equality.WorkerService.Models;

namespace Equality.WorkerService.Comparisons;

public class StructComparison : ComparisonAbstractBase
{
    public StructComparison(ILogger<ComparisonAbstractBase> logger) : base(logger)
    {
    }

    public override void Run()
    {
        Day day1 = new("Monday");
        Day day2 = new("Tuesday");
        Day day3 = new("Monday");

        PrintToConsole(day1.Equals(day2));
        PrintToConsole(day1.Equals(day3));
    }
}
