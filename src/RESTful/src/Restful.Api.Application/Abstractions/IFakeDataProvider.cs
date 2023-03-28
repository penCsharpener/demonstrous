using Restful.Api.Entities;

namespace Restful.Api.Application.Abstractions;

public interface IFakeDataProvider
{
    IEnumerable<Book> GetBooks();
    IEnumerable<Author> GetAuthors();
    IEnumerable<Publisher> GetPublishers();
}