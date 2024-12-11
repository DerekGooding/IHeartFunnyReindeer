using IHeartFunnyReindeer.Content;

namespace IHeartFunnyReindeer.Model;

public class Place(string name, Color color, Action action) : IMenuOption
{
    private string Name { get; } = name;
    private Color Color { get; } = color;
    private Action Action {  get; } = action;

    private readonly Dictionary<Buildable, int> Buildables = [];
    private readonly List<Buildable> IsSeen = [];

    public bool IsDiscovered(Buildables.ByName name) => IsSeen.Contains(name.Id());

    public ColorText Print() => Name.Color(Color);

    public override string ToString() => Name;

    public string LookAround()
    {
        if(Buildables.Count == 0)
        {
            return "There is nothing here...";
        }
        else
        {
            string output = "You see..." + Environment.NewLine;
            foreach(KeyValuePair<Buildable, int> buildable in Buildables)
            {
                if(buildable.Value == 1)
                    output += $"A {buildable.Key}" + Environment.NewLine;
                else
                    output += $"{buildable.Value} {buildable.Key}" + Environment.NewLine;

                if(!IsSeen.Contains(buildable.Key))
                    IsSeen.Add(buildable.Key);
            }
            return output;
        }
    }

    public void AddBuildable(Buildable buildable)
    {
        if(Buildables.TryGetValue(buildable, out int value))
            Buildables[buildable] = ++value;
        else
            Buildables.Add(buildable, 1);
    }

    public void Go() => Action.Invoke();
}
