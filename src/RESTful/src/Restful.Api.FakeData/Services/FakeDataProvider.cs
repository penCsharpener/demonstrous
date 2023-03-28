using Bogus;
using Restful.Api.Application.Abstractions;
using Restful.Api.Entities;

namespace Restful.Api.FakeData.Services;

public sealed class FakeDataProvider : IFakeDataProvider
{
    private static Faker<Book> _bookFaker = new();
    private static Faker<Author> _authorFaker = new();
    private static Faker<Publisher> _publisherFaker = new();

    private static List<Book> _books = new();
    private static List<Author> _authors = new();
    private static List<Publisher> _publishers = new();

    static FakeDataProvider()
    {
        Randomizer.Seed = new Random(42);

        _bookFaker.RuleFor(b => b.YearPublished, f => f.Random.Int(1550, DateTimeOffset.Now.Year))
            .RuleFor(b => b.Title, f => f.Lorem.Slug(f.Random.Int(2, 5)))
            .RuleFor(b => b.Subtitle, f => f.Lorem.Slug(f.Random.Int(5, 12)))
            .RuleFor(b => b.PageCount, f => f.Random.Int(70, 570))
            .RuleFor(b => b.AuthorId, f => f.Random.Int(1, 25))
            .RuleFor(b => b.PublisherId, f => f.Random.Int(1, 25))
            .RuleFor(b => b.Id, f => f.IndexFaker);

        _authorFaker.RuleFor(a => a.FirstName, f => f.Name.FirstName())
            .RuleFor(a => a.LastName, f => f.Name.LastName())
            .RuleFor(a => a.DateOfBirth, f => DateTimeOffset.Now.AddDays(-f.Random.Int(10000, 50000)))
            .RuleFor(b => b.Id, f => f.IndexFaker);

        _publisherFaker.RuleFor(p => p.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Id, f => f.IndexFaker);

        _books.AddRange(_bookFaker.GenerateForever().Take(50));
        _authors.AddRange(_authorFaker.GenerateForever().Take(50));
        _publishers.AddRange(_publisherFaker.GenerateForever().Take(50));
    }

    public IEnumerable<Book> GetBooks()
    {
        foreach (var book in _books)
        {
            book.Author = _authors.FirstOrDefault(a => a.Id == book.AuthorId);
            book.Publisher = _publishers.FirstOrDefault(p => p.Id == book.PublisherId);

            yield return book;
        }
    }

    public IEnumerable<Author> GetAuthors()
    {
        foreach (var author in _authors)
        {
            author.Books = _books.Where(b => b.AuthorId == author.Id).ToList();

            yield return author;
        }
    }

    public IEnumerable<Publisher> GetPublishers()
    {
        foreach (var publisher in _publishers)
        {
            publisher.Books = _books.Where(b => b.PublisherId == publisher.Id).ToList();

            yield return publisher;
        }
    }
}