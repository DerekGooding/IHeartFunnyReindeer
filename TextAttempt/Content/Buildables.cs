using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Buildables
{
    public enum ByName
    {
        Snowman,
        StashOfThings,
        StackOfOrderForms,
        BundleOfWood,
        BoxOfWrapping,
        BucketOfPaint,
    }

    public static List<Buildable> All { get; } = [.. Enum.GetNames<ByName>().Select(x=> new Buildable(ConvertCamelCaseToSpaces(x)))];

    public static Buildable Get(ByName name) => All[(int)name];
}
