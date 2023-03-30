using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful.Api.Application.Abstractions;
using Restful.Api.Context;

namespace Restful.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(_context.Books.Include(b => b.Author).Include(b => b.Publisher).Take(10).ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBooks(int id)
    {
        var book = _context.Books.Where(b => b.Id == id).Take(1).FirstOrDefault();

        if (book is null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}