using IHeartFunnyReindeer.Model;

namespace IHeartFunnyReindeer.Content;

public static class Items
{
    public enum ByName
    {
        Wood,
        Wrapping,
        Box,
        Present,
        Paint,
        Ribbon,
        Tape,
        Wire,
        Snow,
    }

    public static List<Item> All => [.. Enum.GetNames<ByName>().Select(x=> new Item(ConvertCamelCaseToSpaces(x)))];

    public static Item Get(ByName name) => All[(int)name];
}
