using IHeartFunnyReindeer.Model;
using static IHeartFunnyReindeer.Content.Places.ByName;

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
            new(With(MainChamber),
                GlobalSettings.DefaultTextColor,
                GlobalSettings.Service.Exit,
                new(){[Buildables.Get(Buildables.ByName.StashOfThings)] = 1}),
            new(With(Farm),
                Color.Beige,
                () => Menus.FarmMenu.Call()),
            new(With(Workshop),
                Color.Aqua,
                () => Menus.WorkshopMenu.Call()),
            new(With(Office),
                Color.DarkGreen,
                () => Menus.OfficeMenu.Call(),
                new(){[Buildables.Get(Buildables.ByName.StackOfOrderForms)] = 1}),
        ];

    public static Place Get(ByName name) => All[(int)name];

    private static string With(ByName name) => ConvertCamelCaseToSpaces(nameof(name));
}