namespace Restful.Api.Entities;

public sealed class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public int PageCount { get; set; }
    public int YearPublished { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }

    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
}