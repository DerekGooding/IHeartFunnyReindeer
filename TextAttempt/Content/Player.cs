using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Player
{
    public static Dictionary<Item, int> Inventory { get; } = Items.All.ToDictionary(x => x, _ => 0);

    public static void SeeInventory(Item item)
        => GlobalSettings.Service.WriteLine($"You have {Inventory[item]} {item.Name}");

    public static IEnumerable<Item> ExistingInventory => Inventory.Where(x => x.Value > 0).Select(x => x.Key);

    public static void LookAround(Place place) => GlobalSettings.Service.WriteLine(place.LookAround());

    public static void PlaceOrder(Buildable buildable)
    {
        CanOrder = false;
        Places.Get(Places.ByName.Workshop).AddBuildable(buildable);
        Menus.OfficeMenu.Call();
    }

    public static bool CanOrder { get; set; } = true;
}
