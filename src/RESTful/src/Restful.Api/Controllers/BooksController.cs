using Microsoft.AspNetCore.Mvc;
using Restful.Api.Application.Abstractions;

namespace Restful.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IFakeDataProvider _fakeDataProvider;

    public BooksController(IFakeDataProvider fakeDataProvider)
    {
        _fakeDataProvider = fakeDataProvider;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(_fakeDataProvider.GetBooks().Take(10));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBooks(int id)
    {
        var book = _fakeDataProvider.GetBooks().Where(b => b.Id == id).Take(1).FirstOrDefault();

        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}