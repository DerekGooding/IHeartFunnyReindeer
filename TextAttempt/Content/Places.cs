using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Places
{
    public static List<Place> All =>
        [
            new("Main Chamber", GlobalSettings.DefaultTextColor, GlobalSettings.Service.Exit),
            new("Farm", Color.Beige, () => Menus.FarmMenu.Call()),
            new("Workshop", Color.Aqua, () => Menus.WorkshopMenu.Call()),
        ];
}
