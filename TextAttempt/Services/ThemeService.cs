namespace TextAttempt.Services;

public class ThemeService
{
    public event Action? OnChange;
    public string CurrentTheme { get; private set; } = "dark";

    public void ToggleTheme()
    {
        CurrentTheme = CurrentTheme == "light" ? "dark" : "light";
        OnChange?.Invoke();
    }
}