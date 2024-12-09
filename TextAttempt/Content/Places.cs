using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Places
{
    public enum ByName
    {
        MainChamber,
        Farm,
        Workshop,
        Office,
    }

    public static List<Place> All { get; } =
        [
            new(With(ByName.MainChamber),GlobalSettings.DefaultTextColor,GlobalSettings.Service.Exit),
            new(With(ByName.Farm),Color.Beige,() => Menus.FarmMenu.Call()),
            new(With(ByName.Workshop),Color.Aqua,() => Menus.WorkshopMenu.Call()),
            new(With(ByName.Office),Color.DarkGreen,() => Menus.OfficeMenu.Call()),
        ];

    public static Place Get(ByName name) => All[(int)name];

    private static string With(ByName name) => ConvertCamelCaseToSpaces(name.ToString());
}