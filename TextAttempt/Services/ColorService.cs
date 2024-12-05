using TextAttempt.Content;

namespace TextAttempt.Services;

public class ColorService : IColorService
{
    private ConsoleService ConsoleService { get; }
    public ColorService(ConsoleService consoleService)
    {
        GlobalSettings.ColorService = this;
        ConsoleService = consoleService;
        Paragraphs.Greeting.Call();
    }

    public void SetTextColor(Color color) => ConsoleService.CurrentColor = color;
    public void SetTextColor(ConsoleColor consoleColor) => SetTextColor(IColorService.ConsoleColorToDrawingColor(consoleColor));
    public void SetTextColor(byte r, byte g, byte b) => SetTextColor(Color.FromArgb(r, g, b));
    public void SetToDefault() => SetTextColor(GlobalSettings.DefaultTextColor);
}
