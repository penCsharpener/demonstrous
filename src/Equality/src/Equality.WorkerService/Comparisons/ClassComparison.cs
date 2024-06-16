using Equality.WorkerService.Models;

namespace Equality.WorkerService.Comparisons;

public class ClassComparison : ComparisonAbstractBase
{
    private readonly Person _bob;
    private readonly Person _bob2;
    private readonly Person _alison;
    private readonly Author _tim;
    private readonly Author _anna;

    public ClassComparison(ILogger<ClassComparison> logger) : base(logger)
    {
        logger.LogInformation("Initializing {className}", GetType().Name);

        _bob = new Person("Bob", "Stuffcake");
        _bob2 = new Person("Bob", "Stuffcake");
        _alison = new Person("Alison", "Nosila");
        _anna = new Author("Anna", "Nana");
        _tim = _anna;
    }

    public override void Run()
    {
        PrintToConsole(_bob == _alison);
        PrintToConsole(_bob.Equals(_alison));

        PrintToConsole(_bob == _bob2);
        PrintToConsole(_bob.Equals(_bob2));

        PrintToConsole(_anna == _tim);
        PrintToConsole(_anna.Equals(_tim));
    }
}
