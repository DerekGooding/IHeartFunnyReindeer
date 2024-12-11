using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Player
{
    public static Dictionary<Item, int> Inventory { get; } = Items.All.ToDictionary(x => x, _ => 0);

    public static void SeeInventory(Item item)
    {
        GlobalSettings.Service.WriteLine($"You have {Inventory[item]} {item.Name}");
        Paragraphs.PressToContinue(Places.ByName.MainChamber.Id()).Call();
        Places.ByName.MainChamber.Id();
    }

    public static IEnumerable<Item> ExistingInventory => Inventory.Where(x => x.Value > 0).Select(x => x.Key);

    public static void LookAround(Place place)
    {
        GlobalSettings.Service.WriteLine(place.LookAround());
        Paragraphs.PressToContinue(place).Call();
    }

    public static void PlaceOrder(Buildable buildable)
    {
        CanOrder = false;
        Places.ByName.Workshop.Id().AddBuildable(buildable);
        Paragraphs.PressToContinue(Places.ByName.Office.Id()).Call();
    }

    public static bool CanOrder { get; set; } = true;

    public static void Initialize()
    {
        Places.ByName.MainChamber.Id().AddBuildable(Buildables.ByName.StashOfThings.Id());
        Places.ByName.Office.Id().AddBuildable(Buildables.ByName.StackOfOrderForms.Id());
    }
}
