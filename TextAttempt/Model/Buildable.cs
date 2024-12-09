namespace IHeartFunnyReindeer.Model;

public record struct Buildable(string Name) : IMenuOption
{
    public readonly ColorText Print() => Name.DefaultColor();

    public override readonly string ToString() => Name;
}
