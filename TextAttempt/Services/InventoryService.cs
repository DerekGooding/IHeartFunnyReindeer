using IHeartFunnyReindeer.Content;
using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Services;

public class InventoryService
{
    public Dictionary<Item, int> Inventory = Items.All.ToDictionary(x => x, _ => 0);


}
