using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Web.Models;

namespace ShoppingList.Web.Data;
public class ApplicationDbContext : IdentityDbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<ShoppingItem> ShoppingItems { get; set; }
}
