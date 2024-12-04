using static ConsoleHero.MenuBuilder;

namespace TextAttempt;

public static class Menus
{
    public static Menu MainMenu =>
        Title("!-- Main Menu --|").
        Description("Look Around").GoTo(() => { }).
        Cancel();
}
