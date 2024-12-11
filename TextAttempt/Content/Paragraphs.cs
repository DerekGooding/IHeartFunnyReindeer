using IHeartFunnyReindeer.Model;
using static ConsoleHero.ParagraphBuilder;

namespace IHeartFunnyReindeer.Content;

public static class Paragraphs
{
    public static Paragraph Greeting =>
    ClearOnCall().
    Line("Welcome to the North Pole!").
    GoTo(Menus.MainChamber).
    Immediate();

    public static Paragraph PressToContinue(Place place) =>
    Line("Press enter to continue").
    GoTo(place.Go).
    PressToContinue();

    public static Paragraph Help =>
    Line("Secrets revealed!").
    Line("Enter to continue.").
    GoTo(GlobalSettings.Service.Exit).
    PressToContinue();

    public static Paragraph GetSnow =>
        Line("You bend over and scoop up some snow.").
        GoTo(() =>
        {
            Player.Inventory[Items.ByName.Snow.Id()]++;
            if (Player.Inventory[Items.ByName.Snow.Id()] >= 10)
                Menus.FarmMenu.Call();
        }).
        Immediate();

    public static Paragraph MakeSnowman =>
        Line("The snow in your pockets was melting.").
        Line("With a little effort, you manage to build a snowman.").
        GoTo(() =>
        {
            Player.Inventory[Items.ByName.Snow.Id()] -= 10;
            if (Player.Inventory[Items.ByName.Snow.Id()] < 10)
                Menus.FarmMenu.Call();
            Places.ByName.Farm.Id().AddBuildable(Buildables.ByName.Snowman.Id());
        }).
        DelayInSeconds(1);

    public static Paragraph OrderFormMessage =>
        Line("You pick up an order form.").
        Line("You notice there are check boxes for the following items and a pencil to leave a check.").
        Line("Which item would you like to order?").
        GoTo(Menus.OrderFormMenu).
        Immediate();
}
