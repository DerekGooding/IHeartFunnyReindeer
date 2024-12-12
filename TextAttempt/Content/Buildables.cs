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
        Mirror,
        LockedDoor,
    }

    public static List<Buildable> All { get; } =
    [
        With(ByName.Snowman),
        With(ByName.StashOfThings),
        With(ByName.StackOfOrderForms),
        With(ByName.BundleOfWood, true),
        With(ByName.BoxOfWrapping, true),
        With(ByName.BucketOfPaint, true),
        With(ByName.Mirror),
        With(ByName.LockedDoor),
    ];

    private static Buildable With(ByName name, bool canOrder = false) => new(ConvertCamelCaseToSpaces(name.ToString()), canOrder);

    public static IEnumerable<Buildable> Orderable => All.Where(x=> x.CanBeOrdered);
}
