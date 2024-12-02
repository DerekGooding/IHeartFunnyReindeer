namespace TextAttempt;

public record WebMenu : Menu
{
    private List<string> ConsoleLines { get; }

    public WebMenu(Menu original, List<string> consoleLines) : base(original) => ConsoleLines = consoleLines;

    new public void Call(string input = "")
    {
        ConsoleLines.Add("Hello World");
        //if (Count == 0)
        //{
        //    return;
        //}

        //AutoIncrimentKeys();
        //if (ClearOnCall)
        //{
        //    Console.Clear();
        //}

        //if (Title.Text != string.Empty)
        //{
        //    Title.Print();
        //}

        //OuputOptions.Print(Seperator);
        //IMenuOption? menuOption = null;
        //while (menuOption == null)
        //{
        //    string line = Console.ReadLine();
        //    menuOption = FindFirst((MenuOption x) => (!x.IsCaseSensitive) ? string.Equals(x.Key, line, StringComparison.OrdinalIgnoreCase) : string.Equals(x.Key, line));
        //    if (menuOption == null)
        //    {
        //        WriteLine("Not a valid choice" + Environment.NewLine);
        //        continue;
        //    }

        //    for (int i = 0; i < GlobalSettings.Spacing; i++)
        //    {
        //        WriteLine();
        //    }

        //    menuOption.Invoke();
        //}
    }

    public void WriteLine(string text = "") => ConsoleLines.Add(text + Environment.NewLine);
}
