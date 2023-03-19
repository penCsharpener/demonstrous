using Microsoft.AspNetCore.SignalR;
using ShoppingList.Web.Models;

namespace ShoppingList.Web.Hubs;

public class ShoppingHub : Hub
{
  public async Task NotifyNewItem(ShoppingItemNotification item)
  {
    await Clients.Others.SendAsync("ItemListUpdated", item);
  }
}
