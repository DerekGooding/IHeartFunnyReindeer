namespace TextAttempt.Services;

public class ConsoleService : IConsoleService
{
    public ConsoleService() => GlobalSettings.Service = this;
    public Color CurrentColor { get; set; } = GlobalSettings.DefaultTextColor;

    public List<List<TextSegment>> ColoredLines { get; } = [];
    public string UserInput { get; set; } = string.Empty;
    private bool Process { get; set; } = false;

    public void Beep(int frequency, int duration) => throw new NotImplementedException();
    public void Clear() => ColoredLines.Clear();
    public ConsoleKeyInfo ReadKey() => throw new NotImplementedException();
    public string? ReadLine() => throw new NotImplementedException();
    public void Write(string? value)
    {
        if (value == null) return;
        if(ColoredLines.Count == 0)
            ColoredLines.Add([]);

        ColoredLines[^1].Add(new() { Color = AsHex(CurrentColor), Text = value });
    }

    public void WriteLine(string? value)
    {
        if (value == null) return;
        ColoredLines[^1].Add(new() { Color = AsHex(CurrentColor), Text = value });
        ColoredLines.Add([]);
    }

    public void WriteLine() => ColoredLines.Add([]);

    public void ProcessInput() => Process = true;

    private string AsHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
}
