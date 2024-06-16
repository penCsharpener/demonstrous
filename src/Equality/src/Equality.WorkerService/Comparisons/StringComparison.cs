namespace Equality.WorkerService.Comparisons;

public class StringComparison : ComparisonAbstractBase
{
    public StringComparison(ILogger<ComparisonAbstractBase> logger) : base(logger)
    {
    }

    public override void Run()
    {
        var someText = "Text";
        var refCopyOfText = "Text";

        PrintToConsole("string" == "string");
        PrintToConsole("string".Equals("string"));

        PrintToConsole("string" == "String");
        PrintToConsole("string".Equals("String", System.StringComparison.OrdinalIgnoreCase));

        PrintToConsole(someText == refCopyOfText);
        PrintToConsole(someText.Equals(refCopyOfText));
        PrintToConsole(string.ReferenceEquals(someText, refCopyOfText));
    }
}
