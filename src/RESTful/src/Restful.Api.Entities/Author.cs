namespace Restful.Api.Entities;

public sealed class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }

    public IList<Book> Books { get; set; }
}