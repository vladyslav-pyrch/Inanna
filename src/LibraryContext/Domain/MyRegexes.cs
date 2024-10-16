using System.Text.RegularExpressions;

namespace Inanna.LibraryContext.Domain;

public static partial class MyRegexes
{
    [GeneratedRegex(@"^[0-9]+(\.[0-9]+)?$")]
    public static partial Regex NumberRegex();

    [GeneratedRegex(@"^image/[a-z]+$")]
    public static partial Regex ImageContentTypeRegex();

    [GeneratedRegex("^[^\\s].*[^\\s]$")]
    public static partial Regex Trimmed();
}