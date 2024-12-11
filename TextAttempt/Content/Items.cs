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

    public static List<Item> All { get; } = [.. Enum.GetNames<ByName>().Select(x=> new Item(ConvertCamelCaseToSpaces(x)))];
}
