namespace ShoppingList.Web.Models;

public class ShoppingItemNotification : ShoppingItem
{
    public ShoppingItemNotification() { }

    public ShoppingItemNotification(ShoppingItem item)
    {
        Name = item.Name;
        Id = item.Id;
    }

    public bool WasAdded { get; set; }
    public bool WasDeleted { get; set; }
}