using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingList.Web.Models.Configuration;

public class ShoppingItemConfiguration : IEntityTypeConfiguration<ShoppingItem>
{
    public void Configure(EntityTypeBuilder<ShoppingItem> builder) { }
}