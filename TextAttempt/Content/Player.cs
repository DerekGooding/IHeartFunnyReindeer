using TextAttempt.Model;

namespace TextAttempt.Content;

public static class Player
{
    public static Dictionary<Item, int> Inventory { get; } = Items.All.ToDictionary(x => x, _ => 0);

    public static void SeeInventory(Item item) 
        => GlobalSettings.Service.WriteLine($"You have {Inventory[item]} {item.Name}");
}
