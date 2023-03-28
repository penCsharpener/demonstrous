namespace Restful.Api.Entities;

public sealed class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Book> Books { get; set; }
}