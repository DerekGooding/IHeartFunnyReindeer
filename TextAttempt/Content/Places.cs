using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Places
{
    public enum ByName
    {
        MainChamber,
        Farm,
        Workshop,
    }

    public static List<Place> All { get; } =
        [
            new(ConvertCamelCaseToSpaces(nameof(ByName.MainChamber)), GlobalSettings.DefaultTextColor, GlobalSettings.Service.Exit),
            new(ConvertCamelCaseToSpaces(nameof(ByName.Farm)), Color.Beige, () => Menus.FarmMenu.Call()),
            new(ConvertCamelCaseToSpaces(nameof(ByName.Workshop)), Color.Aqua, () => Menus.WorkshopMenu.Call()),
        ];

    public static Place Get(ByName name) => All[(int)name];
}