using static ConsoleHero.MenuBuilder;

namespace IHeartFunnyReindeer.Content;

public static class Menus
{
    public static Menu MainChamber =>
        Title("!-- Main Chamber --|").
        Description("Look Around").GoTo(() =>
        {
            Player.LookAround(Places.Get(Places.ByName.MainChamber));
            Paragraphs.Greeting.Call();
        }).
        Description("Travel").GoTo(MoveMenu).

        Description("Check Stash").
        If(Places.Get(Places.ByName.MainChamber).IsDiscovered(Buildables.Get(Buildables.ByName.StashOfThings))).
        GoTo(Inventory).

        Key("help").IsHidden().GoTo(Paragraphs.Help).
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
        Description("Look Around").GoTo(() => Player.LookAround(Places.Get(Places.ByName.Farm))).
        Description("Pick up Snow").GoTo(Paragraphs.GetSnow).
        Description("Build Snowman").If(() => Player.Inventory[Items.Get(Items.ByName.Snow)] >= 10).GoTo(Paragraphs.MakeSnowman).
        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu WorkshopMenu =>
        Title("!-- Workshop --|", Color.Aqua).
        ClearOnCall().
        Description("Look Around").GoTo(() => Player.LookAround(Places.Get(Places.ByName.Workshop))).
        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu OfficeMenu =>
        Title("!-- Office --|", Color.DarkGreen).
        ClearOnCall().
        Description("Look Around").GoTo(() => Player.LookAround(Places.Get(Places.ByName.Office))).
        Description("Pick up an Order Form").If(Player.CanOrder).GoTo(Paragraphs.OrderFormMessage).
        Description("Travel").GoTo(MoveMenu).
        NoRefuse();

    public static Menu OrderFormMenu =>
    NoTitle().
    OptionsFromList(Buildables.Orderable, Player.PlaceOrder).
    Cancel();
}
