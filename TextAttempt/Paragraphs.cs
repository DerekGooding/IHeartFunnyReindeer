using static ConsoleHero.ParagraphBuilder;

namespace TextAttempt;

public static class Paragraphs
{
    public static Paragraph Greeting =>
    Line("Welcome traveller! What would you like to drink?").
    GoTo(Menus.MainMenu).
    DelayInSeconds(0);
}
