using static ConsoleHero.ParagraphBuilder;

namespace TextAttempt;

public static class Paragraphs
{
    public static Paragraph Greeting =>
    Line("Welcome to the North Pole!").
    Line("Would you like a drink?").
    //GoTo(Menus.MainMenu).
    DelayInSeconds(0);
}
