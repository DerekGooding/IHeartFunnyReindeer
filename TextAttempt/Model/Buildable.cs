namespace IHeartFunnyReindeer.Model;

public record struct Buildable(string Name, bool CanBeOrdered = false) : IMenuOption
{
    public readonly ColorText Print() => $"[] - {Name}".DefaultColor();

    public override readonly string ToString() => Name;
}
