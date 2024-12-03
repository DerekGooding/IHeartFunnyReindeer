using ConsoleHero.Interfaces;

namespace TextAttempt.Services;

public class ConsoleService : IConsoleService
{
    public ConsoleService()
    {
        GlobalSettings.Service = this;
        Paragraphs.Greeting.Call();
    }

    public List<string> ConsoleLines { get; } = [];
    public string UserInput { get; set; } = string.Empty;
    private bool Process { get; set; } = false;

    public void Beep(int frequency, int duration) => throw new NotImplementedException();
    public void Clear() => ConsoleLines.Clear();
    public ConsoleKeyInfo ReadKey() => throw new NotImplementedException();
    public string? ReadLine() => throw new NotImplementedException();
    public void Write(string? value)
    {
        if(ConsoleLines.Count == 0)
            ConsoleLines.Add(string.Empty);
        ConsoleLines[^1] += value;
    }

    public void WriteLine(string? value)
    {
        if(value != null)
            ConsoleLines.Add(value);
    }

    public void WriteLine() => ConsoleLines.Add(string.Empty);

    public void ProcessInput() => Process = true;
}
