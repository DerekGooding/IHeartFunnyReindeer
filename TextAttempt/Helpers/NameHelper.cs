using IHeartFunnyReindeer.Content;
using IHeartFunnyReindeer.Model;
using System.Text.RegularExpressions;

namespace IHeartFunnyReindeer.Helpers;

internal static partial class NameHelper
{
    public static string ConvertCamelCaseToSpaces(string camelCaseString)
        => string.IsNullOrEmpty(camelCaseString) ? camelCaseString : MyRegex().Replace(camelCaseString, " $1");

    [GeneratedRegex("(?<=.)([A-Z])")]
    private static partial Regex MyRegex();

    public static Place Id(this Places.ByName name) => Places.All[(int)name];
    public static Item Id(this Items.ByName name) => Items.All[(int)name];
    public static Buildable Id(this Buildables.ByName name) => Buildables.All[(int)name];
}