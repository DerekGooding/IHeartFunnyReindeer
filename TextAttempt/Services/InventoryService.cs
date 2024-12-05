using TextAttempt.Content;
using TextAttempt.Model;

namespace TextAttempt.Services;

public class InventoryService
{
    public Dictionary<Item, int> Inventory = Items.All.ToDictionary(x => x, _ => 0);


}
