namespace HeapStack.WorkerService.Models;
internal class PersonClass
{
    public required string Name { get; set; }
}

internal struct PersonStruct
{
    public string Name { get; set; }
}

internal record PersonRecord
{
    public required string Name { get; set; }
}

internal record struct PersonRecordStruct
{
    public string Name { get; set; }
}