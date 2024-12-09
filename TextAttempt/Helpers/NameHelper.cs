using System.Text.RegularExpressions;

namespace IHeartFunnyReindeer.Helpers;

internal static partial class NameHelper
{
    public static string ConvertCamelCaseToSpaces(string camelCaseString)
        => string.IsNullOrEmpty(camelCaseString) ? camelCaseString : MyRegex().Replace(camelCaseString, " $1");

    [GeneratedRegex("(?<=.)([A-Z])")]
    private static partial Regex MyRegex();
}