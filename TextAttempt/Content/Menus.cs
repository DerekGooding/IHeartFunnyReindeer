using IHeartFunnyReindeer.Services;
using static ConsoleHero.MenuBuilder;

namespace IHeartFunnyReindeer.Content;

public static class Menus
{
    public static Menu MainChamber =>
        Title("!-- Main Chamber --|").
        Description("Look Around").GoTo(() => Player.LookAround(Places.ByName.MainChamber.Id())).
        Description("Travel").GoTo(MoveMenu).

        Description("Check Stash").
        If(Places.ByName.MainChamber.Id().IsDiscovered(Buildables.ByName.StashOfThings)).
        GoTo(Inventory).

        Key("help").IsHidden().GoTo(Paragraphs.Help).
        Key("shake").IsHidden().GoTo(() => ((ConsoleService)GlobalSettings.Service).ToggleShake()).
        NoRefuse();

    public static Menu Inventory =>
        Title("!-- Inventory --|").
        OptionsFromList(Player.ExistingInventory, Player.SeeInventory).
        Description("Nothing").If(!Player.ExistingInventory.Any()).GoTo(GlobalSettings.Service.Exit).
        NoRefuse();

    public static Menu MoveMenu =>
        Title("Where do you want to go?").
        OptionsFromList(Places.All, (x) => x.Go()).
        NoRefuse();

    public static Menu FarmMenu =>
        Title("!-- Farm --|", Color.Beige).
        ClearOnCall().
        Description("Look Around").GoTo(() => Player.LookAround(Places.ByName.Farm.Id())).
        Description("Pick up Snow").GoTo(Paragraphs.GetSnow).
        Description("Build Snowman").If(() => Player.Inventory[Items.ByName.Snow.Id()] >= 10).GoTo(Paragraphs.MakeSnowman).
        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu WorkshopMenu =>
        Title("!-- Workshop --|", Color.Aqua).
        ClearOnCall().
        Description("Look Around").GoTo(() => Player.LookAround(Places.ByName.Workshop.Id())).
        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu OfficeMenu =>
        Title("!-- Office --|", Color.DarkGreen).
        ClearOnCall().
        Description("Look Around").GoTo(() => Player.LookAround(Places.ByName.Office.Id())).

        Description("Pick up an Order Form").
        If(Player.CanOrder && Places.ByName.Office.Id().IsDiscovered(Buildables.ByName.StackOfOrderForms)).
        GoTo(Paragraphs.OrderFormMessage).

        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu OrderFormMenu =>
    NoTitle().
    OptionsFromList(Buildables.Orderable, Player.PlaceOrder).
    Cancel();
}
