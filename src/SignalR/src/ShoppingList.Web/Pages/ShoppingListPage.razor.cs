using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Web.Data;
using ShoppingList.Web.Models;

namespace ShoppingList.Web.Pages;

public partial class ShoppingListPage : IAsyncDisposable
{
    private HubConnection? hubConnection;
    public ShoppingItem NewItem { get; set; } = new();
    public List<ShoppingItem> ShoppingItems { get; set; } = new();

    [Inject]
    public IServiceScopeFactory ScopeFactory { get; set; } = default!;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        using (var scope = ScopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            ShoppingItems = await context.ShoppingItems.ToListAsync();
        }

        var url = Navigation.ToAbsoluteUri("/shoppingaction");
        hubConnection = new HubConnectionBuilder()
            .WithUrl(url)
            .WithAutomaticReconnect()
            .ConfigureLogging(conf => conf.AddConsole()).Build();

        hubConnection.On<ShoppingItemNotification>("ItemListUpdated", item =>
        {
            if (item.WasDeleted && ShoppingItems.FirstOrDefault(s => s.Id == item.Id) is { } existingItem)
            {
                ShoppingItems.Remove(existingItem);
            }

            if (item.WasAdded)
            {
                ShoppingItems.Add(item);
            }

            InvokeAsync(StateHasChanged);
        });

        await hubConnection.StartAsync();
    }

    private async Task HandleSubmitAsync()
    {
        Console.WriteLine(NewItem.Name);
        if (string.IsNullOrEmpty(NewItem.Name))
        {
            Console.WriteLine("Name cannot be empty for shopping item.");
            return;
        }

        using var scope = ScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.ShoppingItems.Add(NewItem);

        await context.SaveChangesAsync();

        var notification = new ShoppingItemNotification(NewItem)
        {
            WasAdded = true
        };

        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("NotifyNewItem", notification);
        }

        ShoppingItems.Add(NewItem);
        NewItem = new();
    }

    private async Task HandleDeleteAsync(int id)
    {
        using var scope = ScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var item = await context.ShoppingItems.FirstOrDefaultAsync(s => s.Id == id);

        var notification = new ShoppingItemNotification(item)
        {
            WasDeleted = true
        };

        context.ShoppingItems.Remove(item);

        if (hubConnection is not null)
        {
            await hubConnection.SendAsync("NotifyNewItem", notification);
        }

        ShoppingItems.Remove(ShoppingItems.First(s => s.Id == id));

        await context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}