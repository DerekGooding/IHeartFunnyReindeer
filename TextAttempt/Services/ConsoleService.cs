using IHeartFunnyReindeer.Content;
using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Services;

public class ConsoleService : IConsoleService
{
    public bool Shake;
    public void ToggleShake() => Shake = !Shake;

    private IListeningNode CurrentListener = Paragraphs.Greeting;
    public void SetListener(IListeningNode listener) => CurrentListener = listener;

    public ConsoleService()
    {
        GlobalSettings.Service = this;
        GlobalSettings.Spacing = 0;
        Player.Initialize();
    }

    public Color CurrentColor { get; set; } = GlobalSettings.DefaultTextColor;

    public List<List<TextSegment>> ColoredLines { get; } = [];
    public string UserInput { get; set; } = string.Empty;

    public void Beep(int frequency, int duration) => throw new NotImplementedException();
    public void Clear()
    {
        ColoredLines.Clear();
        ColoredLines.Add([new TextSegment() { Text = " " }]);
    }

    public void Write(string? value)
    {
        if (value == null) return;
        if (ColoredLines.Count == 0)
            ColoredLines.Add([]);

        ColoredLines[^1].Add(new() { Color = AsHex(CurrentColor), Text = value });
    }

    public void WriteLine(string? value)
    {
        if (value == null) return;
        ColoredLines[^1].Add(new() { Color = AsHex(CurrentColor), Text = value });
        ColoredLines.Add([new TextSegment() { Text = " " }]);
    }

    public void WriteLine() => ColoredLines.Add([new TextSegment() { Text = " " }]);

    public void ProcessInput()
    {
        CurrentListener.ProcessResult(UserInput);
        UserInput = string.Empty;
    }

    private string AsHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    public void Cancel() => throw new NotImplementedException();
    public void Exit() => Paragraphs.Greeting.Call();
}
