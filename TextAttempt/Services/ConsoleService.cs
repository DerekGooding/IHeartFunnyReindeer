using IHeartFunnyReindeer.Content;
using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Services;

public class ConsoleService : IConsoleService
{
    private readonly List<IListeningNode> ListenerQueue = [];
    public void SetListener(IListeningNode listener) => ListenerQueue.Add(listener);

    public ConsoleService()
    {
        GlobalSettings.Service = this;
        GlobalSettings.Spacing = 0;
        Places.Get(Places.ByName.MainChamber).AddBuildable(Buildables.Get(Buildables.ByName.StashOfThings));
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
        ListenerQueue[^1].ProcessResult(UserInput);
        UserInput = string.Empty;
    }

    private string AsHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    public void Cancel()
    {
        ListenerQueue.RemoveAt(ListenerQueue.Count - 1);
        if (ListenerQueue.Count == 0)
            Paragraphs.Greeting.Call();
        ProcessInput();
    }
    public void Exit()
    {
        ListenerQueue.Clear();
        Paragraphs.Greeting.Call();
    }
}
