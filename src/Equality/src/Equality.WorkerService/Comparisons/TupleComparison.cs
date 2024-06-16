namespace Equality.WorkerService.Comparisons;

public class TupleComparison : ComparisonAbstractBase
{
    public TupleComparison(ILogger<ComparisonAbstractBase> logger) : base(logger)
    {
    }

    public override void Run()
    {
        Tuple<string, int> tuple1 = new("eleven", 11);
        Tuple<string, int> sameAsTuple1 = new("eleven", 11);
        Tuple<string, int> tuple2 = new("eleven", 12);

        PrintToConsole(tuple1.Equals(sameAsTuple1));
        PrintToConsole(ReferenceEquals(tuple1, sameAsTuple1));
        PrintToConsole(tuple1 == sameAsTuple1);
        PrintToConsole(tuple1.Equals(tuple2));
        PrintToConsole(tuple1 == tuple2);
    }
}