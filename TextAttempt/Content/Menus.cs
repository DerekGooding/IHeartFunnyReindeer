using static ConsoleHero.MenuBuilder;

namespace TextAttempt.Content;

public static class Menus
{
    public static Menu MainChamber =>
        Title("!-- Main Chamber --|").
        Description("Look Around").GoTo(Paragraphs.SeeNothing).
        Description("Move").GoTo(MoveMenu).
        Description("Check Inventory").GoTo(Inventory).
        Key("help").IsHidden().GoTo(Paragraphs.Help).
        NoRefuse();

    public static Menu Inventory =>
        Title("!-- Inventory --|").
        OptionsFromList(Player.ExistingInventory, Player.SeeInventory).
        Exit();

    public static Menu MoveMenu =>
        Title("Where do you want to go?").
        OptionsFromList(Places.All, (x) => x.Go()).
        Cancel();

    public static Menu FarmMenu =>
        Title("!-- Farm --|", Color.Beige).
        ClearOnCall().
        Description("Look Around").GoTo(Paragraphs.SeeNothing).
        Description("Move").GoTo(MoveMenu).
        NoRefuse();

    public static Menu WorkshopMenu =>
        Title("!-- Workshop --|", Color.Aqua).
        ClearOnCall().
        Description("Look Around").GoTo(Paragraphs.SeeNothing).
        Description("Move").GoTo(MoveMenu).
        NoRefuse();
}
