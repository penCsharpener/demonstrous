using Restful.Api.Application.Abstractions;
using Restful.Api.Context;

namespace Restful.Api.FakeData.Services;

public sealed class InMemoryDataInitializer
{
    private readonly IFakeDataProvider _dataProvider;
    private readonly LibraryContext _context;

    public InMemoryDataInitializer(IFakeDataProvider dataProvider, LibraryContext context)
    {
        _dataProvider = dataProvider;
        _context = context;
    }

    public async Task PopulateAsync(CancellationToken token = default)
    {
        _context.Books.AddRange(_dataProvider.GetBooks());
        _context.Authors.AddRange(_dataProvider.GetAuthors());
        _context.Publishers.AddRange(_dataProvider.GetPublishers());

        await _context.SaveChangesAsync(token);
    }
}