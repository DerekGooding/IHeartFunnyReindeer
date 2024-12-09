namespace IHeartFunnyReindeer.Model;

public record struct Item(string Name) : IMenuOption
{
    public readonly ColorText Print() => Name.DefaultColor();
}
