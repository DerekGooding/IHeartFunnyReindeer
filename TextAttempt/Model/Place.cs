namespace IHeartFunnyReindeer.Model;

public record struct Place(string Description, Color Color, Action Action) : IMenuOption
{
    public readonly ColorText Print() => Description.Color(Color);

    public readonly void Go() => Action.Invoke();
}
