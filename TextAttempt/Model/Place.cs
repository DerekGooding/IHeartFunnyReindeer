namespace IHeartFunnyReindeer.Model;

public class Place(string Name, Color Color, Action Action, Dictionary<Buildable, int>? buildables = null) : IMenuOption
{
    public ColorText Print() => Name.Color(Color);

    public override string ToString() => Name;

    public void Go() => Action.Invoke();

    public Dictionary<Buildable, int> Buildables = buildables ?? [];

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
}
